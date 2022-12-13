using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour {
    public string back;
    public string again;
    public void PlayGame()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(again);
    }
    public void QuitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(back);
    } 
}
