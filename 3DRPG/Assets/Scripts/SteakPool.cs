using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
namespace aa
{
    public class SteakPool : MonoBehaviour
    {
        /// <summary>
        /// 逼
        /// </summary>
        [SerializeField, Header("ψ逼")]
        GameObject steak;
        ObjectPool<GameObject> steakPool;
        [SerializeField, Header("ψ逼程计秖"), Range(0, 1000)]
        int maxSteakc = 30;
        int count = 0;
        private void Awake()
        {
            steakPool = new ObjectPool<GameObject>(CreatPool, GetSteak, ReleaseSteak, DestroySteak, false, maxSteakc);
        }
        /// <summary>
        /// pool create
        /// </summary>
        /// <returns></returns>
        GameObject CreatPool()
        {
            count++;
            GameObject temp = Instantiate(steak);
            temp.name = steak.name + " " + count;
            return temp;
        }
        /// <summary>
        /// 眖pool
        /// </summary>
        /// <param name="steak"></param>
        void GetSteak(GameObject steak)
        {
            steak.SetActive(true);
        }
        /// <summary>
        /// pool
        /// </summary>
        /// <param name="steak"></param>
        void ReleaseSteak(GameObject steak)
        {
            steak.SetActive(false);
        }
        /// <summary>
        /// 计秖禬筁程计秖
        /// </summary>
        /// <param name="steak"></param>
        void DestroySteak(GameObject steak)
        {
            Destroy(steak);
        }
        /// <summary>
        /// 场怠眔poolずン
        /// </summary>
        public GameObject GetSteakPool()
        {
            return steakPool.Get();
        }
        /// <summary>
        /// 盢ンpool
        /// </summary>
        /// <param name="steak"></param>
        public void ReleaseSteakPool(GameObject steak)
        {
            steakPool.Release(steak);
        }
    }

}

