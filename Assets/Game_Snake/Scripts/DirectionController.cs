using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    private Rigidbody rb;
    RaycastHit hit;
  
    private float v,w;
    // Start is called before the first frame update
    void Start()
    {
        w = Config.config.spinning_speed;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,0,1);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = InputProcessor.input.getHor();
        //Debug.Log(moveHorizontal);
        Vector3 head_part = SnakeController.player.getForward();
        v = SnakeController.player.getV();
        Vector3 movement = new Vector3(head_part.z, 0, -head_part.x).normalized * moveHorizontal;
            //head_part.transform.right * moveHorizontal;
        //Debug.Log("   "+movement);


        rb.AddForce(movement*w, ForceMode.VelocityChange);
        //ForceMode
        rb.velocity=rb.velocity.normalized * v;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.tag == "Ground")
            {
                Debug.Log("hit!");
                if (hit.distance >= Config.config.on_ground) rb.useGravity = true;
                else rb.useGravity = false;
            }
            //else Debug.Log(hit.collider.tag);
        }
    }
}
