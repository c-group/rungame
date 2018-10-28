using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Ranking : MonoBehaviour {

    public List<Text> scoretext = new List<Text>();
    public List<Text> stagetext = new List<Text>();
    public List<Image> charaimage = new List<Image>();
    public List<Text> startext = new List<Text>();
    public List<Image> rankimage = new List<Image>();
    static List<ScoreRank> sr = new List<ScoreRank>();

    int[] scoreArray;
    int[] charaArray;
    string[] stageArray;
    int[] starArray;
    int[] rankArray;

    public Sprite Soldier;
    public Sprite Priest;
    public Sprite Wizard;

    public Sprite S;
    public Sprite A;
    public Sprite B;
    public Sprite C;

    public struct ScoreRank
    {
        public int chara;
        public int score;
        public string stage;
        public int star;
        public int rank;

        public ScoreRank(int chara, int score, string stage, int star, int rank)
        {
            this.chara = chara;
            this.score = score;
            this.stage = stage;
            this.star = star;
            this.rank = rank;
        }
    }

    void Start () {
        //PlayerPrefs.DeleteAll();
        scoreArray = PlayerPrefsX.GetIntArray("score");
        charaArray = PlayerPrefsX.GetIntArray("chara");
        stageArray = PlayerPrefsX.GetStringArray("stage");
        starArray = PlayerPrefsX.GetIntArray("star");
        rankArray = PlayerPrefsX.GetIntArray("rank");

        Debug.Log(charaArray[9]);
        Debug.Log(scoreArray[9]);
        Debug.Log(stageArray[9]);
        Debug.Log(starArray[9]);
        Debug.Log(rankArray[9]);

        for (int i = 0; i < 10; i++)
        {
            sr.Add(new ScoreRank(charaArray[i], scoreArray[i], stageArray[i], starArray[i], rankArray[i]));
        }

        sr.Sort((a, b) => b.score.CompareTo(a.score));

        for (int i = 0; i < 10; i++)
        {
            scoretext[i].text = sr[i].score.ToString();
            stagetext[i].text = sr[i].stage;
            startext[i].text = sr[i].star.ToString();
            
            // フラグによってそれに合った画像に差し替える
            if (sr[i].chara == 0)
            {
                charaimage[i].sprite = Soldier;
            }
            else if (sr[i].chara == 1)
            {
                charaimage[i].sprite = Priest;
            }
            else if (sr[i].chara == 2)
            {
                charaimage[i].sprite = Wizard;
            }

            if (sr[i].rank == 0)
            {
                rankimage[i].sprite = C;
            }
            else if (sr[i].rank == 1)
            {
                rankimage[i].sprite = B;
            }
            else if (sr[i].rank == 2)
            {
                rankimage[i].sprite = A;
            }
            else if (sr[i].rank == 3)
            {
                rankimage[i].sprite = S;
            }
        }

        sr.Clear();
        
    }

}
