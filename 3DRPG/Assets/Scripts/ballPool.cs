using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPool : MonoBehaviour
{
    public delegate void DelegateHit(GameObject ball);
    public DelegateHit delegateHit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("¦aªO"))
        {
            delegateHit(gameObject);
        }
    }

}
