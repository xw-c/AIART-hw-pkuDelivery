using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public static ObstacleGenerator gen;
    const int variety = 6;
    public GameObject[] obstacle = new GameObject[variety];
    public GameObject road;
    List<GameObject> Obstacle = new List<GameObject>();
    List<GameObject> Road = new List<GameObject>();
    
    int roadinit = 20;
    int roadcount;
    float blocklen = 5;

    void Awake(){
        gen = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(roadcount = 0; roadcount < roadinit;){
            generateRoad();
        }
    }

    // Update is called once per frame
    public void generateObstacle(float x)
    {
        float tmp = Random.Range(1,4), z = -tmp*5;
//        Debug.Log(z);
        Vector3 pos = new Vector3(x,0,z);
        Vector3 angle = new Vector3(0, Random.Range(0,360),0);
        int choose = Random.Range(0,variety);
        GameObject obj = Instantiate(obstacle[choose], pos, Quaternion.Euler(angle));
        Obstacle.Add(obj);
    }
    public void generateRoad()
    {
        float c=Random.value;
        if(c>0.7f&&roadcount>=4)generateObstacle(roadcount*blocklen);
        Vector3 pos = new Vector3((roadcount+1) * blocklen, 0, 0);
        GameObject obj = Instantiate(road, pos, Quaternion.identity);
        Road.Add(obj);
        roadcount++;
    }
    public int getRoadLen(){
        return roadcount;
    }
}
