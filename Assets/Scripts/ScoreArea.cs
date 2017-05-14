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

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            onBallScored(myPlayerNumber);
            //have game manager lesten to this event and reset level?
        }

    }
}
