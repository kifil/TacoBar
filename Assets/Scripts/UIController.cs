using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public PlayerNumber myPlayerNumber;
    public Text scoreText;

    void OnEnable()
    {
        ScoreController.onScoreChanged += this.UpdateScore;
    }

    private void OnDisable()
    {
        ScoreController.onScoreChanged -= this.UpdateScore;
    }

    private void UpdateScore(PlayerNumber playerNum, int newScore)
    {
        if(playerNum == myPlayerNumber)
        {
            scoreText.text = newScore.ToString();
        }

    }



}
