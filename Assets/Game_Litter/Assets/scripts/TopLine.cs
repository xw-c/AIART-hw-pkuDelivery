using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLine : MonoBehaviour
{
    public GameObject gameWinCanvas;
    public GameObject gameOverCanvas;
    public bool IsMove = false;
    public float speed = 0.1f;
    public float limit_y = -5f;
    public int win_score = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMove)
        {
            if (this.transform.position.y>limit_y)
            {
                this.transform.Translate(Vector3.down*speed);
            }
        }
        
    }

    //触发碰撞
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Fruit"))
        {
            //判断游戏是否结束
            if ((int)GameManager.gameManagerInstance.gameState < (int)GameState.GameOver)
            {
                if (collider.gameObject.GetComponent<fruit>().fruitState==FruitState.Collision)
                {
                    //gameover
                    GameManager.gameManagerInstance.gameState = GameState.GameOver;
                    Invoke("OpenMoveAndCalculateScore",0.1f);
                    if(GameManager.gameManagerInstance.TotalScore < 5)
                        gameOverCanvas.SetActive(true);
                    else 
                        gameWinCanvas.SetActive(true);
                    //销毁剩余水果，计算分数
                }
            }

            //计算分数
            if (GameManager.gameManagerInstance.gameState == GameState.CalculateScore)
            {
                float currentScore = collider.GetComponent<fruit>().fruitScore;
                GameManager.gameManagerInstance.TotalScore += currentScore;
                GameManager.gameManagerInstance.totalScore.text = GameManager.gameManagerInstance.TotalScore.ToString();
                Destroy(collider.gameObject);
            }

        }
    }

//打开红线下移开关并计算分数
    void OpenMoveAndCalculateScore()
    {
        IsMove = true;
        GameManager.gameManagerInstance.gameState = GameState.CalculateScore;
    }

    
}
