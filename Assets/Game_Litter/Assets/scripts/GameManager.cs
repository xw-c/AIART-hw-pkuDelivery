using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameState //游戏状态
{
    Ready = 0,
    StandBy = 1,
    InProgress = 2,
    GameOver = 3,
    CalculateScore = 4,
}

public class GameManager : MonoBehaviour
{
    public GameObject[] fruitList;
    public GameObject bornFruitPosition;

    public GameObject startBtn;

    public static GameManager gameManagerInstance; //静态的，所以直接在别的类中使用

    public GameState gameState = GameState.Ready;

    public Vector3 combineScale = new Vector3(0,0,0);

    public float TotalScore = 0f;

    public Text totalScore;

    //在游戏对象启用前调用，优先级高于start
    void Awake()
    {
        gameManagerInstance = this;
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        //游戏开始
        Debug.Log("start");
        CreateFruit();
        gameState = GameState.StandBy; //点击鼠标之后
        startBtn.SetActive(false);
    }


    public void InvokeCreateFruit(float invokeTime) //延迟创建水果
    {
        Invoke("CreateFruit", invokeTime);
    }


    public void CreateFruit()
    {
        int index = Random.Range(0,5);
        if (fruitList.Length>=index && fruitList[index]!=null)
        {
            GameObject fruitObj = fruitList[index];
            var currentFruit = Instantiate(fruitObj, bornFruitPosition.transform.position,fruitObj.transform.rotation);
            currentFruit.GetComponent<fruit>().fruitState = FruitState.StandBy;
        }
    }

    //currentFruitType 当前碰撞的水果类型
    //currentPos 当前碰撞的水果位置
    //collisionPos 碰撞的对方的位置

    public void CombineNewFruit(FruitType currentFruitType, Vector3 currentPos, Vector3 collisionPos)
    {
        Vector3 centerPos = (currentPos+collisionPos)/2; //中心位置
        int index = (int)currentFruitType + 1;
        GameObject combineFruitObj = fruitList[index];
        var combineFruit = Instantiate(combineFruitObj, centerPos, combineFruitObj.transform.rotation);
        combineFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
        combineFruit.GetComponent<fruit>().fruitState = FruitState.Collision;
        // CombineFruit.transform.localScale = combineScale; //尺寸变化
    }
}
