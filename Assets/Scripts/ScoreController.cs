using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public PlayerNumber myPlayerNumber;

    public delegate void ScoreControllerHandler(PlayerNumber playerNum, int newScore);
    public static event ScoreControllerHandler onScoreChanged;

    private int score = 0;
    private int pointsToWin = 3;

    void OnEnable()
    {
        ScoreArea.onBallScored += this.IncreaseScore;
    }

    private void OnDisable()
    {
        ScoreArea.onBallScored -= this.IncreaseScore;
    }

    void IncreaseScore(PlayerNumber playerNumber)
    {
        if(playerNumber == myPlayerNumber)
        {
            score++;
            onScoreChanged(myPlayerNumber, score);
            if(score >= pointsToWin)
            {
                GameOver();
            }
        }

    }

    void GameOver()
    {
        //myPlayerNumber wins!
    }


}
