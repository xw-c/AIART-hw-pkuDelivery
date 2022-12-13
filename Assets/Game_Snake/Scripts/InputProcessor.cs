using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProcessor : MonoBehaviour
{
    public static InputProcessor input;
    private float moveHorizontal;
    private float moveVertical; 
    private bool pause;

    // Use this for initialization
    private void Awake()
    {
        Time.timeScale = 1;
        input = this;
    }

    // Update is called once per frame
    void Update () {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        pause = Input.GetKeyDown("escape");//return
        if (pause) {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }
    }

    public float getHor(){
        return moveHorizontal;
    }
    public float getVer(){
        return moveVertical;
    }
}
