using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
namespace aa
{
    public class SteakPool : MonoBehaviour
    {
        /// <summary>
        /// ���Ʀ�
        /// </summary>
        [SerializeField, Header("�ױ�")]
        GameObject steak;
        ObjectPool<GameObject> steakPool;
        [SerializeField, Header("�ױƳ̤j�ƶq"), Range(0, 1000)]
        int maxSteakc = 30;
        int count = 0;
        private void Awake()
        {
            steakPool = new ObjectPool<GameObject>(CreatPool, GetSteak, ReleaseSteak, DestroySteak, false, maxSteakc);
        }
        /// <summary>
        /// pool create��
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
        /// �qpool���X
        /// </summary>
        /// <param name="steak"></param>
        void GetSteak(GameObject steak)
        {
            steak.SetActive(true);
        }
        /// <summary>
        /// ��^pool
        /// </summary>
        /// <param name="steak"></param>
        void ReleaseSteak(GameObject steak)
        {
            steak.SetActive(false);
        }
        /// <summary>
        /// �ƶq�W�L�̤j�ƶq��
        /// </summary>
        /// <param name="steak"></param>
        void DestroySteak(GameObject steak)
        {
            Destroy(steak);
        }
        /// <summary>
        /// �~�����f�A���opool������
        /// </summary>
        public GameObject GetSteakPool()
        {
            return steakPool.Get();
        }
        /// <summary>
        /// �N�����^pool
        /// </summary>
        /// <param name="steak"></param>
        public void ReleaseSteakPool(GameObject steak)
        {
            steakPool.Release(steak);
        }
    }

}

