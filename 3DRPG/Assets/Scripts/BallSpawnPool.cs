using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering.HighDefinition;

public class BallSpawnPool : MonoBehaviour
{
    /// <summary>
    /// 使用物件池生成
    /// </summary>
    // Start is called before the first frame update
    [SerializeField, Header("欲置物")]
    GameObject ball;
    ObjectPool<GameObject> objectPool;

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreatePool,GetBall,ReleaseBall,DestroyBall,false,100);
        InvokeRepeating("Spawn", 0.0f, 0.01f);
    }

    /// <summary>
    /// 建立pool要做的事
    /// </summary>
    /// <returns></returns>
    GameObject CreatePool()
    {
        return Instantiate(ball);
    }
    /// <summary>
    /// 從物件池拿出物件時
    /// </summary>
    /// <param name="ball"></param>
    void GetBall(GameObject ball)
    {
        ball.SetActive(true);
    }
    /// <summary>
    /// 把東西還給物件池
    /// </summary>
    /// <param name="ball"></param>
    void ReleaseBall(GameObject ball)
    {
        ball.SetActive(false);
    }
    /// <summary>
    /// 數量超出物件池容量時要做的
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
