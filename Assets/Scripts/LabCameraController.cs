using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class LabCameraController : MonoBehaviour
{
    public RawImage img;
    public Texture[] sp = new Texture[4];
    public GameObject[] cam = new GameObject[2];
    public GameObject nextcanvas;
    int idx = 0;
    // Start is called before the first frame update
    void Start()
    {
        idx++;
        img.texture = sp[0];
        img.color = new Color(255, 255, 255);
        cam[0].SetActive(false);
        cam[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalInputProcessor.input.getEnter()){
            if(idx==0){
        
            }
            else if(idx==1){
                idx++;
                img.texture = sp[1];
            
            }
            else if(idx==2){
                idx++;
                img.texture = sp[2];
            
            }
            else if(idx==3){
                idx++;
                img.texture = sp[3];
            }
            else if(idx==4){
                idx++;
                cam[1].SetActive(false);
                cam[0].SetActive(true);
                nextcanvas.SetActive(true);
            }
        }
    }
}
