using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConfig : MonoBehaviour
{
    public static GlobalConfig config;

    public float rotate_speed = 0.2f;

    private void Awake()
    {
        config = this;
    }
}
