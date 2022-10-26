using aa;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(200)]
public class SpawnDogPoint : MonoBehaviour
{
    DogPool dogPool;
    GameObject enemyObj;
    [SerializeField,Header("重新生成時間範圍")]
    Vector2 randomRespawn = new Vector2(2,5);
    private void Awake()
    {
        dogPool = GameObject.Find("DOGPOOL").GetComponent<DogPool>();
        SpawnDog();
    }
    void SpawnDog()
    {
        enemyObj = dogPool.GetSteakPool();
      
        enemyObj.transform.position = transform.position;
        enemyObj.GetComponent<EnemyHealth>().onDead = EnemyDead;
    }
    void EnemyDead()
    {
        dogPool.ReleaseSteakPool(enemyObj);
        float randomTime = Random.Range(randomRespawn.x, randomRespawn.y);
        Invoke("SpawnDog", randomTime);
    }
}
