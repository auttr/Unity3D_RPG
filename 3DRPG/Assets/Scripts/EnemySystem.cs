using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace aa
{
    /// <summary>
    /// 敵人遊走，追蹤，攻擊
    /// </summary>
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField, Header("敵人資料")]
        DataEnemy enemyData;
        Animator ani;
        NavMeshAgent nma;
        Vector3 v3Target ;
        string parWalk = "開關走路";
        [SerializeField, Header("狀態")]
        EnemyState enemyState;
        float timeIde;
        bool IsrandomTime;
        //random time
        float r;
        [SerializeField, Header("追蹤目標圖層")]
        LayerMask layerTarget;
        string parAttack = "觸發攻擊";
        private void Awake()
        {
            ani = GetComponent<Animator>();
            nma = GetComponent<NavMeshAgent>();
            nma.speed = enemyData.speedWalk;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, enemyData.rangeAtk);

            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, enemyData.rangeTrace);

            Gizmos.color = new Color(0, 0, 1, 1);
            Gizmos.DrawSphere(v3Target, 1f);
        }
        // Start is called before the first frame update


        // Update is called once per frame
        void Update()
        {
            SwitchState();
            CheckTargetInRange();
        }
        void Wander()
        {
            if (nma.remainingDistance == 0)
            {
                v3Target = new Vector3(29.85f, 2.22f, -30.87f) + Random.insideUnitSphere * enemyData.rangeTrace;
                IsrandomTime = true;

            }
            ani.SetBool(parWalk, nma.velocity.magnitude > 0.1f);
            nma.SetDestination(v3Target);
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
                r = Random.Range(enemyData.timeRange.x, enemyData.timeRange.y);
                IsrandomTime = false;
            }
            if (timeIde > r)
            {
                timeIde = 0;
                enemyState = EnemyState.Wander;

            }

        }
        /// <summary>
        ///範圍偵測 
        /// </summary>
        void CheckTargetInRange()
        {
            if (enemyState== EnemyState.Attack) return;

            Collider[] hits = Physics.OverlapSphere(transform.position, enemyData.rangeTrace, layerTarget);
            if (hits.Length > 0)
            {
                v3Target = hits[0].transform.position;
                enemyState = EnemyState.Track;
            }
        }
        void Track()
        {
            nma.SetDestination(v3Target);
            ani.SetBool(parWalk, true);
            if(Vector3.Distance(transform.position,v3Target)<=enemyData.rangeAtk)
            {
                enemyState = EnemyState.Attack;
                print("攻擊");
            }
        }
        float timerAttack;
        void Attack()
        {
            ani.SetBool(parWalk, false);
            nma.velocity = Vector3.zero;
            if(timerAttack<enemyData.attackCD)
            {
                timerAttack += Time.deltaTime;
            }else
            {
                ani.SetTrigger(parAttack);
                timerAttack = 0;
            }
        }
    }

}
