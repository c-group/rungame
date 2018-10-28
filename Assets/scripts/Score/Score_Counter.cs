using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Counter : MonoBehaviour {

    private int score;
    private int distancepoint;
    private static int total;
    private bool score_item = false;
    private float time = 0;

    // Use this for initialization
    void Start () {
        score = 0;
        distancepoint = 0;
        total = 0;
	}
	
	// Update is called once per frame
	void Update () {
        score = Score.getScore();
        if (score_item)
        {
            time += Time.deltaTime;
            if (time >= 20)
            {               
                GameObject.Find("Item_Bgm").GetComponent<AudioSource>().enabled = false;
                GameObject.Find("bgm").GetComponent<AudioSource>().enabled = true;
                time = 0;
                score_item = false;
            }
        }
    }

    public void SetItem()
    {
        score_item = true;
    }

    public bool GetItem()
    {
        return score_item;
    }
}
