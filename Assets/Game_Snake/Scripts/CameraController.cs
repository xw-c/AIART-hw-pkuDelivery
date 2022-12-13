using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject head;
    private float up;
    private float behind;
    //const Vector3 up_unit_vec = new Vector3(0,1,0);

    void Start(){
        up = transform.position.y - head.transform.position.y;
        behind = transform.position.z - head.transform.position.z;
    }
    void LateUpdate()
    {
        transform.forward = SnakeController.player.getForward();
        transform.position = head.transform.position + (behind * transform.forward + up * new Vector3(0,1,0));
    }
}
