using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public string s;
    public void Change(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(s);
        // RenderSettings.skybox = skybox;
        // this.gameObject.SetActive(false);
        // nextarrow.SetActive(true);
        // Debug.Log("change!");
    }
    // void onMouseDown(){
    //     Debug.Log("print!");
    // }Z
}
