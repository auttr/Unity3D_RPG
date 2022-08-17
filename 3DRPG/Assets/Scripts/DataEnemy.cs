using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace aa
{
    /// <summary>
    /// �ĤH���
    /// </summary>
    [CreateAssetMenu(menuName = "Auttr/Data Enemy", fileName = "Data Enemy", order = 1)]
    public class DataEnemy : ScriptableObject
    {
        // Start is called before the first frame update
        [SerializeField, Header("��q"), Range(0, 2000)]
        public float HP;
        [SerializeField, Header("�����O"), Range(0, 200)]
        public float ATK;
        [SerializeField, Header("���ʳt��"), Range(0, 100)]
        public float speedWalk;
        [SerializeField, Header("�l�ܶZ��"), Range(0, 200)]
        public float rangeTrace;
        [SerializeField, Header("�����Z��"), Range(0, 20)]
        public float rangeAtk;
        [SerializeField, Header("�������v"), Range(0, 1)]
        public float probabilityProp;
        [SerializeField, Header("�����D��")]
        public GameObject goProp;
        [SerializeField, Header("�����H���ɶ�")]
        public Vector2 timeRange;
        [SerializeField, Header("�������j"), Range(0, 5)]
        public float attackCD;

        // Update is called once per frame

    }

}
