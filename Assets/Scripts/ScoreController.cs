using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public delegate void ScoreControllerHandler(PlayerNumber playerNum, int newScore);
    public static event ScoreControllerHandler onScoreChanged;

    private static int[] scores;

    void OnEnable()
    {
        ScoreArea.onBallScored += this.IncreaseScore;
    }

    private void OnDisable()
    {
        ScoreArea.onBallScored -= this.IncreaseScore;
    }

    void Start()
    {
        if(scores == null)
        {
            SetInitialScores();
        }
    }

    //TODO: call this  on start from the menu scene 
    static void SetInitialScores()
    {
        int numberOfPlayers = GameController.GetCurrentPlayerCount();
        scores = new int[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
        {
            scores[i] = 0;
        }
    }

    void IncreaseScore(PlayerNumber playerNumber)
    {
        scores[(int)playerNumber]++;
        onScoreChanged(playerNumber, scores[(int)playerNumber]);

        if (scores[(int)playerNumber] >= GameController.GetPointsToWin())
        {
            GameController.TriggerGameOver(playerNumber);
        }
    }

    public static int GetScore(PlayerNumber playerNumber)
    {
        return scores[(int)playerNumber];
    }
}
