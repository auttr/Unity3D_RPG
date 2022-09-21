using auttr;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
namespace aa
{
    /// <summary>
    /// ¦å¶q¨t²Î
    /// </summary>
    public class PlayerHealth : HealthSystem
    {
        Thirdcamera tc;
        protected override  void Awake()
        {
            base.Awake();
            tc = GetComponent<Thirdcamera>();
        }
        protected override void Dead()
        {
            base.Dead();
            tc.enabled = false;
        }
    }

}
