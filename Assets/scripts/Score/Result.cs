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
        int distancepoint = TimeCount.getDis_Score() * 10;
        total = score + distancepoint;
        resultText.text = "撃破ポイント:" + score.ToString();
        distanceText.text = "踏破ポイント:" + distance.ToString() + "m ・・・" + distancepoint.ToString();
        totalscoreText.text = "合計:" + total.ToString();
    }

    public static int getTotal()
    {
        return total;
    }
}
