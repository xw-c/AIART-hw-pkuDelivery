using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    private int count;
    public Text counttext;
    public Text eattext;
    public Slider slide;
    private AudioSource audio;
    public GameObject gamewincanvas;
    public GameObject gameovercanvas;

    void Start(){
        count = 0;
        setCountContext();
        eattext.text = "";
        slide.value = 0;
        audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" || other.tag == "Snake")
        {
            // UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver Menu");
            gameovercanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else if (other.tag == "Food")
        {
            /*
            score += 10;
            UIManager.instance.AddScore(score);
            audioSource.Play();
            */
            count += 1;
            setCountContext();
            Destroy(other.gameObject);
            SnakeController.player.AddBodyPart();
            FoodController.food.CreateFood();

            audio.Play();
            slide.value+=1;
            
            if(slide.value==slide.maxValue){
                gamewincanvas.SetActive(true);
                Time.timeScale = 0;
            }
            else{
                eattext.text = "Yummy ! !";
                Invoke("finisheat", 1);
            }
        }
    }
    private void setCountContext(){
        counttext.text = "Score: "+count.ToString();
    }
    private void finisheat(){
        eattext.text = "";
    }
}
