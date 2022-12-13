using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public GameObject charater;
    private Vector3 behind;
    //const Vector3 up_unit_vec = new Vector3(0,1,0);

    void Start(){
        behind = transform.position - charater.transform.position;
    }
    void LateUpdate()
    {
        transform.position = charater.transform.position + behind;
    }
}
