using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config config;
    
    //for snake
    public float forward_speed = 1;
    public float spinning_speed = 1;
    public float speed_up = 0.5f;
    public int init_len = 4;//包括头
    public float block_len = 1;
    public float on_ground = 0.5f;//开启重力贴地的阈值

    //for food
    public int food_num = 4;
    public float x_scale = 9;
    public float food_height = 1;
    public float z_scale = 9;
    private void Awake()
    {
        config = this;
    }
}
