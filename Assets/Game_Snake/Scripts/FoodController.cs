using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    // Start is called before the first frame update
    int n;
    float x_scale,y,z_scale;

    const int variety = 3;
    public GameObject[] food_prefab = new GameObject[variety];
    //public GameObject food_prefab2;
    public static FoodController food;

    void Awake(){
        food = this;
    }
    void Start()
    {
        n = Config.config.food_num;
        x_scale = Config.config.x_scale;
        z_scale = Config.config.z_scale;
        y = Config.config.food_height;
        for(int i = 0; i < n; i++)
            CreateFood();
    }

    public void CreateFood(){
        float x = Random.Range(-x_scale, x_scale);
        float z = Random.Range(-z_scale, z_scale);
        int choose = Random.Range(0,variety);
        //Debug.Log(x + " " + y + ' ' + z);
        GameObject food_sample = Instantiate(food_prefab[choose], new Vector3(x, y, z), Quaternion.identity);
    }
}
