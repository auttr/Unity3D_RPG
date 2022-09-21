using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

namespace aa
{
    /// <summary>
    /// �ĤH�C���A�l�ܡA����
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("�ĤH���")]
        DataEnemy enemyData;
        Animator ani;
        NavMeshAgent nma;
        Vector3 v3Target;
        string parWalk = "�}������";
        [SerializeField, Header("���A")]
        EnemyState enemyState;
        float timeIde;
        bool IsrandomTime;
        //random time
        float r;
        [SerializeField, Header("�l�ܥؼйϼh")]
        LayerMask layerTarget;
        string parAttack = "Ĳ�o����";
        EnemyAttack enemyAttack;
        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            nma.speed = enemyData.speedWalk;
            enemyAttack = GetComponent<EnemyAttack>();
        }
        private void OnDrawGizmosSelected()
        {
            //�����Z��
            Gizmos.color = new Color(1, 0, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, enemyData.rangeAtk);
            //�l�ܶZ��
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, enemyData.rangeTrace);
            //�l�ܥؼЦ�m
            Gizmos.color = new Color(0, 0, 1, 1);
            Gizmos.DrawSphere(v3Target, 1f);
        }

        void Update()
        {
            //�������A
            SwitchState();
            //�ˬd�d�򦳵L�ؼ�
            CheckTargetInRange();
        }
      
        void SwitchState()
        {
            switch (enemyState)
            {
                case EnemyState.Idle:
                    Ide();
                    break;
                case EnemyState.Wander:
                    Wander();
                    break;
                case EnemyState.Attack:
                    Attack();
                    break;
                case EnemyState.Track:
                    Track();
                    break;
            }
        }
        void Ide()  
        {
            nma.velocity = Vector3.zero;
            ani.SetBool(parWalk, false);
            timeIde += Time.deltaTime;
            if (IsrandomTime)
            {
                //�����H���ɶ�
                r = Random.Range(enemyData.timeRange.x, enemyData.timeRange.y);
                IsrandomTime = false;
            }
            if (timeIde > r)
            {
                timeIde = 0;
                enemyState = EnemyState.Wander;

            }

        }
        void Wander()
        {
            if (nma.remainingDistance == 0)//�l�ܳѾl�Z���k�s�A�ؼ��ܦ���Τ����N�I
            {
                v3Target = new Vector3(29.85f, 2.22f, -30.87f) + Random.insideUnitSphere * enemyData.rangeTrace;
                IsrandomTime = true;
            }
            ani.SetBool(parWalk, nma.velocity.magnitude > 0.1f);
            //�]�l�ܥت��a
            nma.SetDestination(v3Target);
        }
        /// <summary>
        ///�d�򰻴� 
        /// </summary>
        void CheckTargetInRange()
        {


            Collider[] hits = Physics.OverlapSphere(transform.position, enemyData.rangeTrace, layerTarget);
            if (hits.Length > 0)
            {
                v3Target = hits[0].transform.position;
                if (enemyState == EnemyState.Attack) return;
                enemyState = EnemyState.Track;
            }
            else//���}�d��l��
            {
                enemyState = EnemyState.Track;
            }
        }
        void Track()
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("����"))
            {
                nma.velocity = Vector3.zero;
            }
            nma.SetDestination(v3Target);
            ani.SetBool(parWalk, true);
            ani.ResetTrigger(parAttack);
            if (Vector3.Distance(transform.position, v3Target) <= enemyData.rangeAtk)
            {
                enemyState = EnemyState.Attack;
            }
            else
            {
                timerAttack = enemyData.attackCD;
            }
        }
        float timerAttack;
        void Attack()
        {
            ani.SetBool(parWalk, false);
            nma.velocity = Vector3.zero;
            if (timerAttack < enemyData.attackCD)
            {
                timerAttack += Time.deltaTime;
            }
            else
            {
                ani.SetTrigger(parAttack);
                timerAttack = 0;
                enemyAttack.StartAttack();
                enemyState = EnemyState.Track;
            }
        }
        private void OnDisable()
        {
            nma.isStopped = true;
        }
    }

}
