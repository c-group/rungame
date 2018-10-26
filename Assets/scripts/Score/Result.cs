using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {


   // public Score score;
    public Text resultText;
    public Text distanceText;
    public Text totalscoreText;
    public Text starText;

    public Image chara;
    public Image rankimage;

    public Sprite Soldier;
    public Sprite Priest;
    public Sprite Wizard;

    public Sprite S;
    public Sprite A;
    public Sprite B;
    public Sprite C;

    static int total;

    // Use this for initialization
    void Start()
    {        
        int score = Score.getScore();
        int distance = TimeCount.getDis_Score();
        int distancepoint = TimeCount.getDis_Score() * 5;
        int star = Score.getStar();
        total = score + distancepoint + (star*100);
        resultText.text = score.ToString() + ("pt");
        distanceText.text = distancepoint.ToString() + ("pt");
        starText.text = star.ToString() + ("×100pt");
        totalscoreText.text = total.ToString() + ("pt");
        FindObjectOfType<HiScore_Manager>().Save();

        if (Character_Flag.GetS_Flag() == 1)
        {
            chara.sprite = Soldier;
        }
        else if (Character_Flag.GetP_Flag() == 1)
        {
            chara.sprite = Priest;
        }
        else if (Character_Flag.GetW_Flag() == 1)
        {
            chara.sprite =Wizard;
        }        

        if(total < 5000)
        {
            rankimage.sprite = C;
        }
        else if(total < 10000)
        {
            rankimage.sprite = B;
        }
        else if (total < 15000)
        {
            rankimage.sprite = A;
        }
        else
        {
            rankimage.sprite = S;
        }

    }

    public static int getTotal()
    {
        return total;
    }
        
}
