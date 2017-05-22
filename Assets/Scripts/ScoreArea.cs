using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour {

    public PlayerNumber myPlayerNumber;

    public delegate void ScoreAreaHandler(PlayerNumber playerNumber);
    public static event ScoreAreaHandler onBallScored;

    // Use this for initialization
    void Start () {
	}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && myPlayerNumber == PlayerNumber.player1)
        {
            TestAddScore();
        }
        if (Input.GetKeyDown(KeyCode.P) && myPlayerNumber == PlayerNumber.player2)
        {
            TestAddScore();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            onBallScored(myPlayerNumber);
        }

    }

    void TestAddScore()
    {
        onBallScored(myPlayerNumber);
    }
}
