using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSeed : MonoBehaviour
{
    public int seed;
    public int game_exist;
    // Start is called before the first frame update
    void Start()
    {
        seed = 0;
        game_exist = 0;
    }

    public int GetSeed()
    {
        if(seed == 0)
        {
            seed = (int)System.DateTime.Now.Ticks;
            //Debug.Log("Init random seed is " + seed.ToString());
        }
        return seed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
