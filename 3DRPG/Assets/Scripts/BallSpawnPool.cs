using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering.HighDefinition;

public class BallSpawnPool : MonoBehaviour
{
    /// <summary>
    /// �ϥΪ�����ͦ�
    /// </summary>
    // Start is called before the first frame update
    [SerializeField, Header("���m��")]
    GameObject ball;
    ObjectPool<GameObject> objectPool;

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreatePool,GetBall,ReleaseBall,DestroyBall,false,100);
        InvokeRepeating("Spawn", 0.0f, 0.01f);
    }

    /// <summary>
    /// �إ�pool�n������
    /// </summary>
    /// <returns></returns>
    GameObject CreatePool()
    {
        return Instantiate(ball);
    }
    /// <summary>
    /// �q��������X�����
    /// </summary>
    /// <param name="ball"></param>
    void GetBall(GameObject ball)
    {
        ball.SetActive(true);
    }
    /// <summary>
    /// ��F���ٵ������
    /// </summary>
    /// <param name="ball"></param>
    void ReleaseBall(GameObject ball)
    {
        ball.SetActive(false);
    }
    /// <summary>
    /// �ƶq�W�X������e�q�ɭn����
    /// </summary>
    /// <param name="ball"></param>
    void DestroyBall(GameObject ball)
    {
        Destroy(ball);
    }
    void Spawn()
    {
        Vector3 pos;
        pos.x = Random.Range(14, -12);
        pos.z = Random.Range(10, -10);
        pos.y = 7;
        GameObject tempBall = objectPool.Get();
        tempBall.transform.position = pos;
        tempBall.GetComponent<ballPool>().delegateHit = HitAndRelease;
    }
    void HitAndRelease(GameObject ball)
    {
        objectPool.Release(ball);
    }

}
