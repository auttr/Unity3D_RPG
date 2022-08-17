using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace aa
{
    /// <summary>
    /// 敵人資料
    /// </summary>
    [CreateAssetMenu(menuName = "Auttr/Data Enemy", fileName = "Data Enemy", order = 1)]
    public class DataEnemy : ScriptableObject
    {
        // Start is called before the first frame update
        [SerializeField, Header("血量"), Range(0, 2000)]
        public float HP;
        [SerializeField, Header("攻擊力"), Range(0, 200)]
        public float ATK;
        [SerializeField, Header("移動速度"), Range(0, 100)]
        public float speedWalk;
        [SerializeField, Header("追蹤距離"), Range(0, 200)]
        public float rangeTrace;
        [SerializeField, Header("攻擊距離"), Range(0, 20)]
        public float rangeAtk;
        [SerializeField, Header("掉落機率"), Range(0, 1)]
        public float probabilityProp;
        [SerializeField, Header("掉落道具")]
        public GameObject goProp;
        [SerializeField, Header("等待隨機時間")]
        public Vector2 timeRange;
        [SerializeField, Header("攻擊間隔"), Range(0, 5)]
        public float attackCD;

        // Update is called once per frame

    }

}
