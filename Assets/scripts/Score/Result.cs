using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {


   // public Score score;
    public Text resultText;
    public Text distanceText;
    public Text totalscoreText;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    ScoreStar script1;
    ScoreStar script2;
    ScoreStar script3;


    // Use this for initialization
    void Start () {
        script1 = star1.GetComponent<ScoreStar>();
        script2 = star2.GetComponent<ScoreStar>();
        script3 = star3.GetComponent<ScoreStar>();
        int score = Score.getScore();
        int distance = TimeCount.getDis_Score();
        int distancepoint = TimeCount.getDis_Score() * 10;
        int total = score + distancepoint;
        resultText.text = "撃破ポイント:" + score.ToString();
        distanceText.text = "踏破ポイント:" + distance.ToString() + "m × 10 =" + distancepoint.ToString();
        totalscoreText.text = "合計:" + total.ToString();
        script1.Lighitng_Up(total);
        script2.Lighitng_Up(total);
        script3.Lighitng_Up(total);
    }


}
