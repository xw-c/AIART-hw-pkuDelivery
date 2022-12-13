using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject IntroPanel;
    public GameObject IntroRawImage;
    public GameObject IntroCat1;
    public GameObject IntroCat2;
    public GameObject IntroCat3;
    public GameObject IntroCat4;
    public int FinishIntro = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && FinishIntro == 0)
        {
            IntroPanel.SetActive(false);
            IntroRawImage.SetActive(false);
            IntroCat1.SetActive(false);
            IntroCat2.SetActive(false);
            IntroCat3.SetActive(false);
            IntroCat4.SetActive(false);
            FinishIntro = 1;
        }
    }
}
