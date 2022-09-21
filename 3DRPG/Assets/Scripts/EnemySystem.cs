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
        Vector3 v3Target;
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
            //攻擊距離
            Gizmos.color = new Color(1, 0, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, enemyData.rangeAtk);
            //追蹤距離
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Gizmos.DrawSphere(transform.position, enemyData.rangeTrace);
            //追蹤目標位置
            Gizmos.color = new Color(0, 0, 1, 1);
            Gizmos.DrawSphere(v3Target, 1f);
        }

        void Update()
        {
            //切換狀態
            SwitchState();
            //檢查範圍有無目標
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
                //等待隨機時間
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
            if (nma.remainingDistance == 0)//追蹤剩餘距離歸零，目標變成圓形內任意點
            {
                v3Target = new Vector3(29.85f, 2.22f, -30.87f) + Random.insideUnitSphere * enemyData.rangeTrace;
                IsrandomTime = true;
            }
            ani.SetBool(parWalk, nma.velocity.magnitude > 0.1f);
            //設追蹤目的地
            nma.SetDestination(v3Target);
        }
        /// <summary>
        ///範圍偵測 
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
            else//離開範圍追蹤
            {
                enemyState = EnemyState.Track;
            }
        }
        void Track()
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊"))
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
