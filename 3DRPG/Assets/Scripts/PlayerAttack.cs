using auttr;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace aa
{
    public class PlayerAttack : AttackSystem
    {

        Thirdcamera tc;
        string paraAtt = "Ä²µo§ðÀ»";
        protected override void Awake()
        {
            base.Awake();
            tc = GetComponent<Thirdcamera>();
        }
        private void Update()
        {
            AttackInput();
        }
        void AttackInput()
        {
            if (!canAttack) return;

            if (Input.GetMouseButtonDown(0))
            {
                tc.enabled = false;
                ani.SetTrigger(paraAtt);
                StartAttack();
            }
        }
        protected override void StopAttack()
        {
            tc.enabled = true;
        }
    }

}
