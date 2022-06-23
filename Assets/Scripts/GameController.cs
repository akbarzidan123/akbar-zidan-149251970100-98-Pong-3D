using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private int scoreP1;
    private int scoreP2;
    private int scoreP3;
    private int scoreP4;
    [Header("UiScore")]
    public Text uIScoreP1;
    public Text uIScoreP2;
    public Text uIScoreP3;
    public Text uIScoreP4;
    [Header("")]
    public int winCount;
    public GameObject[] paddle;
    public GameObject[] wall;
    private bool dead1 = true;
    private bool dead2 = true;
    private bool dead3 = true;
    private bool dead4 = true;
    private int counterPlayer;
    public GameObject winPopUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int index)
    {
        if(index == 1)
        {
            scoreP1+=1;
            uIScoreP1.text = ""+scoreP1;
            if(scoreP1 == winCount)
            {
                DeadPaddle(index-1);
                dead1 = false;
                counterPlayer++;
            }
        }
        if(index == 2)
        {
            scoreP2+=1;
            uIScoreP2.text = ""+scoreP2;
            if(scoreP2 == winCount)
            {
                DeadPaddle(index-1);
                dead2 = false;
                counterPlayer++;
            }
        }
        if(index == 3)
        {
            scoreP3+=1;
            uIScoreP3.text = ""+scoreP3;
            if(scoreP3 == winCount)
            {
                DeadPaddle(index-1);
                dead3 = false;
                counterPlayer++;
            }
        }
        if(index == 4)
        {
            scoreP4+=1;
            uIScoreP4.text = ""+scoreP4;
            if(scoreP4 == winCount)
            {
                DeadPaddle(index-1);
                dead4 = false;
                counterPlayer++;
            }
        }
        if(counterPlayer == 3)
        {
            GameOver();
        }
    }
    public void DeadPaddle(int index)
    {
        PaddleController paddleScript = paddle[index].GetComponent<PaddleController>();
        GoalController wallScript = wall[index].GetComponent<GoalController>();
        paddleScript.InActivePaddle();
        wallScript.InActiveCollider();
    }
    public void GameOver()
    {
        WinController componentWin = winPopUp.GetComponent<WinController>();
        if(dead1)
        {
            componentWin.WinPlayerName("Player 1");
        }
        if(dead2)
        {
            componentWin.WinPlayerName("Player 2");
        }
        if(dead3)
        {
            componentWin.WinPlayerName("Player 3");
        }
        if(dead4)
        {
            componentWin.WinPlayerName("Player 4");
        }
        winPopUp.SetActive(true);
        Time.timeScale = 0;
    }
}
