using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   /// <summary>
   /// �y��I��a�Odestroy
   /// </summary>
   /// <param name="collision"></param>
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("�a�O"))
        {
            Destroy(gameObject);
        }
    }
}
