using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Counter : MonoBehaviour {

    private int score;
    private int distancepoint;
    private static int total;

    // Use this for initialization
    void Start () {
        score = 0;
        distancepoint = 0;
        total = 0;
	}
	
	// Update is called once per frame
	void Update () {
        score = Score.getScore();
        distancepoint = TimeCount.getDis_Score() * 10;
        total = score + distancepoint;
    }

    public static int GetTotal()
    {
        return total;
    }
}
