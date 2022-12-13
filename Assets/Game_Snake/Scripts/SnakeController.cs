using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public static SnakeController player;

    //private Rigidbody rb;
  
    private float v,w;
    private float block_len;

    public GameObject body_prefab;
    public GameObject sphere;
    private List<Transform> body = new List<Transform>();//第0个放头自己，

    void Awake(){
        player = this;
    }
    //called before the first frame
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        w = Config.config.spinning_speed;
        v = Config.config.forward_speed;
        block_len = Config.config.block_len;
        body.Add(transform);
        for(int i=1;i<Config.config.init_len;i++){
            AddBodyPart();
        }
    }

    void Update()
    {
        transform.position = sphere.transform.position;   
        transform.forward = sphere.transform.position - body[1].transform.position;     
        RotateHead();
/*        for(int i=body.Count-1;i>=1;i--){
            body[i]=body[i-1];
        }
*/
        //transform.Translate((body[1].position - body[2].position) * v * Time.deltaTime);
        /*
        float moveHorizontal = Input_Processor.input.getHor();
        Debug.Log(moveHorizontal);
        Vector3 movement = new Vector3(0.0f, moveHorizontal * w * Time.deltaTime, 0.0f);
        //Debug.Log((body[1].position - body[2].position));
        Debug.Log(movement);
        transform.Rotate(movement);
*/
        Vector3 next_pos, now_pos;
        float time;
        for (int i = 1; i < body.Count; i++)
        {
            /*curpos = body[i].position; currot = body[i].rotation;
            body[i].position = prepos;  body[i].rotation = prerot;
            prepos = curpos; prerot = currot;
            */
            next_pos = body[i-1].position;
            now_pos = body[i].position;
            time = (next_pos - now_pos).magnitude * Time.deltaTime * getV() / block_len *1.5f;
            body[i].position = Vector3.Lerp(body[i].position, body[i-1].position, time);
            body[i].transform.rotation = Quaternion.Lerp(body[i].transform.rotation, body[i-1].transform.rotation, time);

        }


        //transform.Rotate(transform.up * w * Time.deltaTime * Input_Processor.input.getHor());
        //for(int i=0;i<)
    }

    private void RotateHead(){
        transform.Rotate(-90,90,0);
    }

    public void AddBodyPart(){
        GameObject body_node = Instantiate(body_prefab, body[body.Count - 1].transform.position - new Vector3(0,0,block_len), Quaternion.identity);
        body.Add(body_node.transform);
        v+=Config.config.speed_up;
    }

    public Vector3 getForward(){
        //Debug.Log(transform.position);
        //Debug.Log(body[1].position);
        return transform.position - body[1].position;
    }
    public float getV(){
        Debug.Log(InputProcessor.input.getVer());
        return v * (Mathf.Clamp(InputProcessor.input.getVer(), -1, 1) + 1.5f);
    }

}
