using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {


   // public Score score;
    public Text resultText;
    public Text distanceText;
    public Text totalscoreText;

    static int total;

    // Use this for initialization
    void Start()
    {
        int score = Score.getScore();
        int distance = TimeCount.getDis_Score();
        int distancepoint = TimeCount.getDis_Score() * 5;
        total = score + distancepoint;
        resultText.text = score.ToString();
        distanceText.text = distance.ToString() +  distancepoint.ToString();
        totalscoreText.text = total.ToString();
        FindObjectOfType<HiScore_Manager>().Save();

    }

    public static int getTotal()
    {
        return total;
    }
}
