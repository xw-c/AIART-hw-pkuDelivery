using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class myScore : MonoBehaviour
{
    private double score;
    public Text ScoreText;
    public Text WinText;
    public Text TimerText;
    public GameObject ScorePanel;
    public GameObject WinPanel;
    public float CameraDistanceThreshold;
    private int start_game = 0;
    private float start_time = 0;
    private GameObject toyObj;
    private GameObject Camera;
    // private GameObject Cats;
    private Animator m_Animator;

    private int FinishIntro = 0;

    //��ȡָ������
    private int cryHash0 = Animator.StringToHash("A_cry 0");
    private int cryHash1 = Animator.StringToHash("A_cry");
    private int cryHash2 = Animator.StringToHash("B_cry 0");
    private int cryHash3 = Animator.StringToHash("B_cry");
    private int cryHash4 = Animator.StringToHash("C_Sleep");
    private int idleHash = Animator.StringToHash("A_idle");
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        m_Animator = gameObject.GetComponent<Animator>();
        // ���ط���
        ScoreText.text = "";
        WinText.text = "";
        TimerText.text = "";
        //����panal
        // ScorePanel = GameObject.Find("ScorePanel").gameObject;
        ScorePanel.SetActive(false);
        // WinPanel = GameObject.Find("WinPanel").gameObject;
        WinPanel.SetActive(false);
        // �������
        toyObj = transform.Find("toy_model").gameObject;
        Debug.Log(toyObj.transform.position);
        toyObj.SetActive(false);
        //׷����������λ��
        Camera = GameObject.Find("Controller");
        // Cats = GameObject.Find("Cats");
        CameraDistanceThreshold = 10;
        // Debug.Log(camera.transform.position);
    }

    bool CameraIsNear()
    {
        float dis = (Camera.transform.position.x - transform.position.x) * (Camera.transform.position.x - transform.position.x)
                    + (Camera.transform.position.y - transform.position.y) * (Camera.transform.position.y - transform.position.y)
                    + (Camera.transform.position.z - transform.position.z) * (Camera.transform.position.z - transform.position.z);
        // Debug.Log(gameObject.name + "  " + Camera.transform.position + " " + transform.position+ "  " + dis.ToString());
        // Debug.Log(gameObject.name + "  " + Math.Abs(dis).ToString());
        return Mathf.Sqrt(dis) < CameraDistanceThreshold;
    }

    void CountScore()
    {
        // ���°�ť
        if (Input.GetMouseButton(0))
        {
            // ����--�۷�
            if (m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == idleHash)
            {
                score -= 2.0;
            }
            // ��--��۷�
            else if (m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash0
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash1
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash2
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash3
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash4)
            {
                score -= 5.0;
            }
            // ����--�ӷ�
            else
            {
                score += 1.0;
            }
        }
        else //�������
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash0
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash1
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash2
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash3
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == cryHash4
                || m_Animator.GetCurrentAnimatorStateInfo(0).shortNameHash == idleHash)
            {
                score += 0.0;
            }
            else
            {
                if(Time.time - start_time > 0.5)
                    score -= 0.5;
            }
        }
    }

    void ShowScore()
    {
        // Debug.Log(start_game);
        if (start_game == 0)
        {
            ScoreText.text = "";
            TimerText.text = "";
            WinText.text = "";
            ScorePanel.SetActive(false);
            WinPanel.SetActive(false);
            toyObj.SetActive(false);
        }
        else if (start_game == 1)
        {
            CountScore();
            ScoreText.text = "Score: " + score.ToString();
            TimerText.text = "Time: " + (Math.Max(60 - Time.time + start_time, 0)).ToString();
            WinText.text = "";
            ScorePanel.SetActive(true);
            WinPanel.SetActive(false);
        }
        else
        {
            ScoreText.text = "";
            TimerText.text = "";
            WinText.text = "\nFinal Score: " + score.ToString();
            ScorePanel.SetActive(false);
            WinPanel.SetActive(true);
        }
    }
    
    void TestSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameObject.Find("Cats").GetComponent<RandomSeed>().game_exist == 0)
            {
                GameObject.Find("Cats").GetComponent<RandomSeed>().game_exist = 1;
                start_time = Time.time;
                m_Animator.Play("A_idle");
                score = 0;
                start_game = 1;
            }
        }
    }

    void TestQ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (start_game == 1)
            {
                start_game = 2;
            }
            else if (start_game == 2)
            {
                start_game = 0;
                ShowScore();
                GameObject.Find("Cats").GetComponent<RandomSeed>().game_exist = 0;
            }
        }
    }

    void TestTime()
    {
        if (Time.time - start_time >= 60f)
        {
            if (start_game == 1)
            {
                start_game = 2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FinishIntro == 0)
        {
            FinishIntro = GameObject.Find("IntroCamera").GetComponent<Intro>().FinishIntro;
            if (FinishIntro == 0) return;
        }
        if (!CameraIsNear())
        {
            toyObj.SetActive(false);
        }
        else
        {
            // Near
            TestSpace();
            if (start_game != 0)
            {
                toyObj.SetActive(true);
            }
        }

        if (start_game != 0)
        {
            TestQ();
            TestTime();
            ShowScore();
        }
        
    }
    
}
