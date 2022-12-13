using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class DialogReader : MonoBehaviour
{
    public string dialog_title;
    public RawImage bg=null;
    private List<string> content = new List<string>();
    XmlDocument xml;
    XmlNode xmlNode;
    int idx;
    float start_time;
    float duration;
    Color tmp;

    Text text;

    void Awake(){
        xml = new XmlDocument();
        xml.Load(Application.dataPath + "/Dialogue/dialog.xml");
        text = this.GetComponent<Text>();
    }
    void Start()
    {
        idx = 0;
        tmp = new Color(255,255,255,0);
        bg.color = tmp;
        text.text = "";
        start_time = Time.time;
        xmlNode = xml.SelectSingleNode("Root" + "/" + dialog_title);
        foreach (XmlElement xl in xmlNode)
            content.Add(xl.InnerText);
    }

    // Update is called once per frame
    void Update()
    {
        if(idx==0&&Time.time-start_time >= 2){
            float lerp = (Time.time-start_time-2);
            tmp.a = lerp; bg.color = tmp;
            if(Time.time-start_time >= 3)text.text = content[idx++];
        }
        if(GlobalInputProcessor.input.getEnter()){
            if(idx<content.Count)text.text = content[idx++];
            else if(idx==content.Count){
                idx++;
                start_time = Time.time;
            }
            
        }
        else if(idx>content.Count){
            // tbd!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            float lerp = (Time.time-start_time);
            tmp.a = 1 - lerp; 
            if(bg!=null)bg.color = tmp;
            text.text = "";
        }
    }
}
