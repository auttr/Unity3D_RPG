using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextScene()
    {
     //   Application.LoadLevel(index);  ("scene")
        SceneManager.LoadScene("stage");

    }
    public void QuitScene()
    {
        Application.Quit();
    }
}
