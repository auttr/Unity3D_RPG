using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   /// <summary>
   /// 球體碰到地板destroy
   /// </summary>
   /// <param name="collision"></param>
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("地板"))
        {
            Destroy(gameObject);
        }
    }
}
