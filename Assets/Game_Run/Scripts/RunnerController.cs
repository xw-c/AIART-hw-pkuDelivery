using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerController : MonoBehaviour
{
    public float speed = 7;
    private Animator anim;
    private AnimatorStateInfo state;
    static int jump_state = Animator.StringToHash("Base Layer.jump");
    static int slide_state = Animator.StringToHash("Base Layer.slide");
    public GameObject gamewincanvas;
    public GameObject gameovercanvas;
    public Slider slide;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        anim = GetComponent<Animator>();
        dist = 0;
        slide.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        //float j0 = joystick[0], j1 = joystick[1] ;
        //Debug.Log(joystick);

        float v = speed * Time.deltaTime;
        if((int)dist/5+20>ObstacleGenerator.gen.getRoadLen()) ObstacleGenerator.gen.generateRoad();

        transform.position -= Vector3.left * v;
        dist += v;
        slide.value += v / 20.0f;
        
        if(slide.value==slide.maxValue){
            gamewincanvas.SetActive(true);
            Time.timeScale = 0;
        }

        state = anim.GetCurrentAnimatorStateInfo(0);
        
        if (Input.GetKeyDown("right"))
        {
            float z = transform.position.z > -14 ? -5 : 0;
            transform.position+=new Vector3(0,0,z);
        }
        else if (Input.GetKeyDown("left"))
        {
            float z = transform.position.z < -6 ? 5 : 0;
            transform.position+=new Vector3(0,0,z);
        }
        else if (Input.GetKeyDown("up"))
        {
            anim.SetBool("jump", true);
        }
        else if (Input.GetKeyDown("down"))
        {
            anim.SetBool("slide", true);
        }

        if (state.fullPathHash == jump_state)
        {
            anim.SetBool("jump", false);
        }
        else if (state.fullPathHash == slide_state)
        {
            anim.SetBool("slide", false);
        }

        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("push!!!");
        if (other.gameObject.tag == "Obstacle")
        {
            //Debug.Log("in");
            gameovercanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
