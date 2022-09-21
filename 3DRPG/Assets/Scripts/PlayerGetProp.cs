using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetProp : MonoBehaviour
{
    SteakPool steakPool;
    string propSteak = "Steak";
    private void Awake()
    {
        steakPool = FindObjectOfType<SteakPool>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print(hit.gameObject.name);

        if (hit.gameObject.name.Contains(propSteak))
        {
            
            steakPool.ReleaseSteakPool(hit.transform.root.gameObject);
        }
    }
}
