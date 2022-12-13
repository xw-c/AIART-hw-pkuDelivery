using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FruitType
{
    One=0,
    Two=1,
    Three=2,
    Four=3,
    Five=4,
    Six=5,
    Seven=6,
    Eight=7,
    Nine=8,
    Ten=9,
    Eleven=10,
}

public enum FruitState //水果的状态
{
    Ready = 0,
    StandBy = 1,
    Dropping = 2,
    Collision = 3,
}

public class fruit : MonoBehaviour
{
    public FruitType fruitType = FruitType.One;
    private bool IsMove = false;
    public FruitState fruitState = FruitState.Ready;

    public float limit_x =2f;
    public Vector3 originalScale = Vector3.zero;


    public float scaleSpeed = 0.01f;

    public float fruitScore = 1f;


    void Awake()
    {
        originalScale = new Vector3(0.5f,0.5f,0.5f);
    }

    // Start is called before the first frame update
    // 在游戏对象启动时，调用一次
    void Start()
    {
        
    }

    // Update is called once per frame
    // 更新方法，每一帧执行一次，每一帧的时间可以设置 Time.deltaTime
    void Update()
    {
        //游戏状态standby并且水果也standby 可用鼠标点击控制移动 以及松开掉落
        if (GameManager.gameManagerInstance.gameState == GameState.StandBy&&fruitState==FruitState.StandBy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsMove = true;
            }
            //松开鼠标
            if (Input.GetMouseButtonUp(0) && IsMove)
            {   
                IsMove = false;
                 //改变重力，使水果自己下落
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;//加的f代表参数float

                fruitState = FruitState.Dropping;
                //水果状态修改为drop
                GameManager.gameManagerInstance.gameState = GameState.InProgress; //step2
                //创建新的待命水果
                GameManager.gameManagerInstance.InvokeCreateFruit(0.5f);
             }

            if (IsMove)
            {
                //移动位置
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //屏幕坐标转化为Unity世界坐标
                this.gameObject.GetComponent<Transform>().position = new Vector3(mousePos.x, this.gameObject.GetComponent<Transform>().position.y, this.gameObject.GetComponent<Transform>().position.z); //y,z轴保持本身不变，只变化x
            }
        }

        // x方向进行一个限制
        if (this.transform.position.x > limit_x)
        {
            this.transform.position = new Vector3(limit_x, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x < -limit_x)
        {
            this.transform.position = new Vector3(-limit_x, this.transform.position.y, this.transform.position.z);
        }

        /*
        // 尺寸恢复
        if (this.transform.localScale.x < originalScale.x)
        {
            this.transform.localScale += new Vector3(1,1,1) * scaleSpeed;
        }
        if (this.transform.localScale.x > originalScale.x)
        {
            this.transform.localScale = originalScale;
        }
        */
    }

    //碰撞
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (fruitState == FruitState.Dropping)
        {
            //碰撞到地板
        if (collision.gameObject.tag.Contains("Floor"))
        {
            GameManager.gameManagerInstance.gameState = GameState.StandBy;
            fruitState = FruitState.Collision; //step3
        }
        //碰撞到水果
        if (collision.gameObject.tag.Contains("Fruit"))
        {
            GameManager.gameManagerInstance.gameState = GameState.StandBy;
            fruitState = FruitState.Collision; //step3
        }

        }
        

        print((int)fruitState);

        //Dropping, Collision,可以进行合成
        if ((int)fruitState==3)
        {
            if(collision.gameObject.tag.Contains("Fruit"))
            {
                if(fruitType==collision.gameObject.GetComponent<fruit>().fruitType&&fruitType!=FruitType.Eleven)
                {   
                    // 限制只执行一次合成
                    float thisPosxy = this.transform.position.x + this.transform.position.y;
                    float collisionPosxy = collision.transform.position.x + collision.transform.position.y;
                    if (thisPosxy > collisionPosxy)
                    {
                        //合成，在碰撞位置生成新的水果，尺寸有小变大
                        //两个位置信息，fruitType
                        GameManager.gameManagerInstance.TotalScore += fruitScore;
                        GameManager.gameManagerInstance.CombineNewFruit(fruitType,this.transform.position,collision.transform.position);
                        GameManager.gameManagerInstance.totalScore.text = GameManager.gameManagerInstance.TotalScore.ToString();
                        Destroy(this.gameObject);
                        Destroy(collision.gameObject);
                    }

                }
            }

        }
    }
}
