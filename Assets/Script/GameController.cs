using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject puck,panelWin;
    
    public TextMeshProUGUI TextScoreLeft,TextScoreRight,TextWin;
    public int s1,s2;

    Vector3 spawnPuckLeft = new Vector3(1.7f,0.65f,-12.5f),spawnPuckRight= new Vector3(1.7f,0.65f,12.5f);
    Vector3 spawnLeft,spawnRight;
    GameObject [] Player;
    

    private void Awake() 
    {
        instance = this;   
    }
    void Start()
    {
        
        Player = GameObject.FindGameObjectsWithTag("Player"); 
        spawnLeft = Player[1].transform.position; 
        spawnRight = Player[0].transform.position;
    }


     public void ScoreLeft(int score)
    {
        s1 += score;
        if(s1 <= 3)
        {
            Instantiate(puck, spawnPuckRight,Quaternion.identity);
            Player[0].transform.position = spawnRight;
            Player[1].transform.position = spawnLeft;
            TextScoreLeft.text = s1.ToString();
        }
        if (s1 == 3)
        {
            Time.timeScale = 0;
            TextWin.text = "PLAYER 1 WINS";
            TextWin.color = new Color(115,255,160,255);
            panelWin.SetActive(true);
        }
    }
    public void ScoreRight(int score)
    {
        s2 += score;

        if(s2 <= 3)
        {
            Instantiate(puck, spawnPuckLeft,Quaternion.identity);
            Player[0].transform.position = spawnRight;
            Player[1].transform.position = spawnLeft;
            TextScoreRight.text = s2.ToString();
        }
        if (s2 == 3)
        {
            Time.timeScale = 0;
            TextWin.text = "PLAYER 2 WINS";
            TextWin.color = new Color(255,125,122,255);
            panelWin.SetActive(true);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Load(string scene)
    {
        Application.LoadLevel(scene);
    }
}

