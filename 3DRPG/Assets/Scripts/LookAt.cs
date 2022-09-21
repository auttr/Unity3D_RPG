using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform traCamera;
    private void Awake()
    {
        traCamera = Camera.main.transform;
    }
  
    // Update is called once per frame
    void Update()
    {
        Look();
    }
    void Look()
    {
        transform.LookAt(traCamera);
    }
}
