using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSceneSwitcher : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Cat");
        }
        else if(Input.GetKeyDown(KeyCode.B)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("chaomian");
        }
    }
}
