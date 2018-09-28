using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Ranking : MonoBehaviour {

    public List<Text> scoretext = new List<Text>();
    public List<Text> stagetext = new List<Text>();
    static List<ScoreRank> sr = new List<ScoreRank>();



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
        
        sr.Add(new ScoreRank(1, 10, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 100, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 210, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 1, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 110, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 103, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 1022, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 510, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 510, "アリベオン山地"));
        sr.Add(new ScoreRank(1, 130, "アリベオン山地"));

        sr.Sort((a, b) => b.score.CompareTo(a.score));

        for (int i = 0; i < 10; i++)
        {
            scoretext[i].text = sr[i].score.ToString();
            stagetext[i].text = sr[i].stage;
        }
        
    }
	

    public static int getMin_Score()
    {
        //sr.Sort((a, b) => b.score.CompareTo(a.score));
        return 10; 
            //sr[9].score;
    }

    public static void set_Score(int a, int b, string c)
    {
        sr.RemoveAt(9);
        sr.Add(new ScoreRank(a, b, c));
    }

    public void Save()
    {

    }

}
