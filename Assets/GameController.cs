using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private static int numberOfPlayers = 2;
    private static int pointsToWin = 3;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TestGameReset();
        }
	}

    static void TestGameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static int GetPointsToWin()
    {
        return pointsToWin;
    }

    public static int GetCurrentPlayerCount()
    {
        return numberOfPlayers;
    }

    public static void TriggerGameOver(PlayerNumber playerNumber)
    {
        print(playerNumber + " wins!");
    }
}
