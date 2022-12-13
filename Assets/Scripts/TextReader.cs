using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class TextReader : MonoBehaviour
{
    private List<string> content = new List<string>();
    public string title;
    public GameObject thiscanvas;
    public GameObject nextcanvas;
    XmlNode xmlNode;
    int idx;
    Text canvas;

    Color colorStart = Color.black;
    Color colorEnd = Color.white;
    float duration = 2.0f;
    float start_time = 0;

    void Awake(){
        XmlDocument xml = new XmlDocument();
        xml.Load(Application.dataPath + "/Dialogue/dialog.xml");
        xmlNode = xml.SelectSingleNode("Root/"+title);
        canvas = this.GetComponent<Text>();
    }
    void Start()
    {
        idx=0;
        RenderSettings.skybox.SetColor("_Tint", colorStart);
        foreach (XmlElement xl in xmlNode)
            content.Add(xl.InnerText);
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalInputProcessor.input.getEnter()&&idx<=content.Count){
            if(idx<content.Count)
            canvas.text = canvas.text + "\n" + content[idx++];
            else if(idx==content.Count){
                idx++;
                start_time = Time.time;
            }
        }
        
        else if(idx>content.Count){
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(colorStart, colorEnd, lerp));
            if(lerp>=0.95){
                if(title=="start")UnityEngine.SceneManagement.SceneManager.LoadScene("baijiang");
                else
                {
                    RenderSettings.skybox.SetColor("_Tint", colorStart);
                    thiscanvas.SetActive(false);
                    nextcanvas.SetActive(true);

                }
            }
            //if(lerp)
        }
    }
}
