using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace aa
{
    /// <summary>
    /// ��q�t��
    /// </summary>
    public class EnemyHealth : HealthSystem
    {

        EnemySystem enemySystem;
        Material matDissolve;
        string nameDissolve = "DissolveValue";
        float maxDissolve = 2.5f;
        float minDissolve = -2.2f;
        SteakPool steakPool;
       public delegate void delegateDead();
        /// <summary>
        /// ���`�ƥ�
        /// </summary>
       public delegateDead onDead;

        protected override void Awake()
        {
            base.Awake();
            enemySystem = GetComponent<EnemySystem>();
            matDissolve = GetComponentsInChildren<Renderer>()[0].material;
            //  steakPool = FindObjectOfType<SteakPool>();
            //�����ƪ��|�H����A�|���DOG������A�V���V�h��
            steakPool = GameObject.Find("StealPool").GetComponent<SteakPool>();
           
          
        }
        private void OnEnable()
        {
            hp = dataHealth.hp;
            imgHealth.fillAmount = 1;
            enemySystem.enabled = true;
            maxDissolve = 2.5f;
            matDissolve.SetFloat(nameDissolve, maxDissolve);
        }
        private void OnDisable()
        {
         
        }
        protected override void Dead()
        {
            base.Dead();
            enemySystem.enabled = false;
            StartCoroutine(Dissolve());
            DropProp();
           
        }
        IEnumerator Dissolve()
        {

            while (maxDissolve > minDissolve)
            {
                maxDissolve += -0.05f;
                matDissolve.SetFloat(nameDissolve, maxDissolve);
                yield return new WaitForSeconds(0.03f);
            }
            onDead();
        }

        /// <summary>
        /// �����D��
        /// </summary>

        void DropProp()
        {
            float value = Random.value;
            if (value <= dataHealth.propProbability)
            {
               // Instantiate(dataHealth.goProp, transform.position + Vector3.up * 3, Quaternion.identity);

                GameObject tempOBJ = steakPool.GetSteakPool();
                tempOBJ.transform.position = transform.position + Vector3.up * 3;
            }
        }

    }
}

