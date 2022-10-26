using aa;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace aa
{
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("攻擊資料")]
        DataAttack dataAttack;
        [SerializeField, Header("動畫名稱")]
        string nameAnimation;

        protected bool canAttack = true;
        protected Animator ani;
        protected virtual void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = dataAttack.attackAreaColor;
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position + transform.TransformDirection(dataAttack.attackAreaoffset),
                transform.rotation,
                transform.localScale
                 );
            Gizmos.DrawCube(Vector3.zero, dataAttack.attackAreaSize);
        }
        public void StartAttack()
        {
            if (!canAttack) return;

            StartCoroutine(AttaclFlow());



        }
        IEnumerator AttaclFlow()
        {
            canAttack = false;
            yield return new WaitForSeconds(dataAttack.attackDelay);
            CheckAttackArea();
            yield return new WaitForSeconds(dataAttack.waitAttackEnd);
            canAttack = true;
            StopAttack();
        }
        /// <summary>
        /// 停止攻擊
        /// </summary>
        protected virtual void StopAttack()
        {

        }
        void CheckAttackArea()
        {
            if (!ani.GetCurrentAnimatorStateInfo(0).IsName(nameAnimation)) return;
            Collider[] hits = Physics.OverlapBox(
                transform.position + transform.TransformDirection(dataAttack.attackAreaoffset),
                dataAttack.attackAreaSize / 2,
                transform.rotation
                , dataAttack.layerTarget
                );

            if (hits.Length > 0)
            {
                hits[0].GetComponent<HealthSystem>().Hurt(dataAttack.attack);
            }
        }
    }
}


