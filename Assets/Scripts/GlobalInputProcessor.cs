using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInputProcessor : MonoBehaviour
{
    public static GlobalInputProcessor input;
    public SceneSwitcher arrow;

    private float moveHorizontal;
    private float moveVertical;
    private bool pause;
    private bool enter;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        Debug.Log("Awake!");
        input = this;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");//左右方向键
        moveVertical = Input.GetAxis("Vertical");//上下方向键
        pause = Input.GetKeyDown(KeyCode.Escape);//esc
        enter = Input.GetKeyDown(KeyCode.Space);//return

        if (Input.GetKeyDown(KeyCode.Return))
        {
            arrow.Change();
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("click!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.GetComponent<SceneSwitcher>() != null)
                    hit.collider.gameObject.GetComponent<SceneSwitcher>().Change();
            }
        }
        */
    }

    public float getHor()
    {
        return moveHorizontal;
    }
    public float getVer()
    {
        return moveVertical;
    }
    public bool getEnter()
    {
        return enter;
    }
}
