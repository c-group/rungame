using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Ranking : MonoBehaviour {

    public List<Text> scoretext = new List<Text>();
    public List<Text> stagetext = new List<Text>();
    public List<Image> charaimage = new List<Image>();
    static List<ScoreRank> sr = new List<ScoreRank>();

    int[] scoreArray;
    int[] charaArray;
    string[] stageArray
        ;

    public Sprite Asprite;
    public Sprite Bsprite;
    public Sprite Csprite;

    public struct ScoreRank
    {
        public int chara;
        public int score;
        public string stage;

        public ScoreRank(int chara, int score, string stage)
        {
            this.chara = chara;
            this.score = score;
            this.stage = stage;
        }
    }

    void Start () {

        scoreArray = PlayerPrefsX.GetIntArray("score");
        charaArray = PlayerPrefsX.GetIntArray("chara");
        stageArray = PlayerPrefsX.GetStringArray("stage");

        for (int i = 0; i < 10; i++)
        {
            sr.Add(new ScoreRank(charaArray[i], scoreArray[i], stageArray[i]));
        }

        sr.Sort((a, b) => b.score.CompareTo(a.score));

        for (int i = 0; i < 10; i++)
        {
            scoretext[i].text = sr[i].score.ToString();
            stagetext[i].text = sr[i].stage;
            // フラグによってそれに合った画像に差し替える
            if (sr[i].chara == 0)
            {
                charaimage[i].sprite = Asprite;
            }
            else if (sr[i].chara == 1)
            {
                charaimage[i].sprite = Bsprite;
            }
            else if (sr[i].chara == 2)
            {
                charaimage[i].sprite = Csprite;
            }
        }

        sr.Clear();
        
    }

}
