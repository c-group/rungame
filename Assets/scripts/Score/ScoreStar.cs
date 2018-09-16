using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreStar : MonoBehaviour {

    public int Lighiting_up_point = 0;

	void Start () {
        int result = Score.getScore();
        
        if(Lighiting_up_point <= result)
        {
            this.GetComponent<Image>().color = new Color(1f, 1f, 0f, 1f);
        }
	}
	

}
