
using UnityEngine;
using UnityEngine.UI;

namespace aa
{
    /// <summary>
    /// 血量系統
    /// </summary>
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField,Header("血量資料")]
        protected DataHealth dataHealth;
        [SerializeField, Header("血條")]
        protected Image imgHealth;

        protected float hp;
        Animator ani;
        string paraHurt = "痛觸發";
        string paraDead = "死開關";
        AttackSystem attackSystem;

        protected virtual void Awake()
        {
            ani = GetComponent<Animator>();
            attackSystem = GetComponent<AttackSystem>();
            hp = dataHealth.hp;

        }
        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Dead()
        {
            hp = 0;
            ani.SetBool(paraDead, true);
            attackSystem.enabled = false;

        }
        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage"></param>
        public void Hurt(float damage)
        {
            hp -= damage;
            ani.SetTrigger(paraHurt);
            if (hp <= 0) Dead();
            imgHealth.fillAmount = hp / dataHealth.hpMax;
        }


    }
}


