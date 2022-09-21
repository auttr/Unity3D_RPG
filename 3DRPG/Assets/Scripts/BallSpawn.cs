using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    /// <summary>
    /// 部使用物件池生成
    /// </summary>
 

    [SerializeField, Header("欲置物")]
    GameObject ball;

    private void Awake()
    {
        InvokeRepeating("Spawn", 0.0f, 0.01f);
    }
    void Spawn()
    {
        Vector3 pos;
        pos.x = Random.Range(14, -12);
        pos.z = Random.Range(10, -10);
        pos.y = 7;
        Instantiate(ball,pos,Quaternion.identity);
    }
}
