
using UnityEngine;
using UnityEngine.UI;

namespace aa
{
    /// <summary>
    /// ��q�t��
    /// </summary>
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField,Header("��q���")]
        protected DataHealth dataHealth;
        [SerializeField, Header("���")]
        protected Image imgHealth;

        protected float hp;
        Animator ani;
        string paraHurt = "�hĲ�o";
        string paraDead = "���}��";
        AttackSystem attackSystem;

        protected virtual void Awake()
        {
            ani = GetComponent<Animator>();
            attackSystem = GetComponent<AttackSystem>();
            hp = dataHealth.hp;

        }
        /// <summary>
        /// ���`
        /// </summary>
        protected virtual void Dead()
        {
            hp = 0;
            ani.SetBool(paraDead, true);
            attackSystem.enabled = false;

        }
        /// <summary>
        /// ����
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


