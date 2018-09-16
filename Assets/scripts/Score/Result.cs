using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {


   // public Score score;
    public Text resultText;


    // Use this for initialization
    void Start () {
        int result = Score.getScore();
        resultText.text = result.ToString();
    }
	
	
}
