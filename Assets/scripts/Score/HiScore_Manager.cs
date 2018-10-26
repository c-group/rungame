using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HiScore_Manager : MonoBehaviour {

    int[] scoreArray = new int[10];
    int[] charaArray = new int[10];
    int[] starArray = new int[10];
    int[] rankArray = new int[10];
    string[] stageArray = new string[10];

    static List<ScoreRank> sr = new List<ScoreRank>();
    
    //更新スコア
    private int rankin_score;

    //ステージ情報
    private string stagename;

    //キャラ情報
    private int chara;

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

    // Use this for initialization
    void Start () {
        //PlayerPrefs.DeleteAll();
        if (Stage_Flag.GetAlibeon() == 1)
        {
            stagename = "アリベオン山脈";
        }
        else if (Stage_Flag.GetFiland() == 1)
        {
            stagename = "フィランド城";
        }
        else if (Stage_Flag.GetRobel() == 1)
        {
            stagename = "ロベル城";
        }
        else if (Stage_Flag.GetLeeble() == 1)
        {
            stagename = "レエブル砂漠";
        }
        else if (Stage_Flag.GetVareru() == 1)
        {
            stagename = "ヴァール島";
        }

        if (Character_Flag.GetS_Flag() == 1)
        {
            chara = 0;
        }
        else if (Character_Flag.GetP_Flag() == 1)
        {
            chara = 1;
        }
        else if (Character_Flag.GetW_Flag() == 1)
        {
            chara = 2;
        }

        scoreArray = PlayerPrefsX.GetIntArray("score", 1000, 10);
        charaArray = PlayerPrefsX.GetIntArray("chara", 0, 10);
        stageArray = PlayerPrefsX.GetStringArray("stage", "アリベオン山脈", 10);
        scoreArray = PlayerPrefsX.GetIntArray("star", 0,10);
        rankArray = PlayerPrefsX.GetIntArray("rank", 0, 10);

        for (int i = 0; i < 10; i++)
        {
            sr.Add(new ScoreRank( charaArray[i],scoreArray[i], stageArray[i],starArray[i],rankArray[i]));
        }
        sr.Sort((a, b) => b.score.CompareTo(a.score));

        for(int s = 0; s < 10; s++)
        {
            charaArray[s] = sr[s].chara;
            scoreArray[s] = sr[s].score;
            stageArray[s] = sr[s].stage;
            starArray[s] = sr[s].star;
            rankArray[s] = sr[s].rank;
        }
        sr.Clear();
    }

    public void Save()
    {
        
        if (Result.getTotal() > scoreArray[9])
        {
            FindObjectOfType<Rankin>().rankin();
            charaArray[9] = chara;
            scoreArray[9] = Result.getTotal();
            stageArray[9] = stagename;
            starArray[9] = Score.getStar();
            
            if(Result.getTotal() < 5000)
            {
                rankArray[9] = 0;
            }
            else if (Result.getTotal() < 10000)
            {
                rankArray[9] = 1;
            }
            else if (Result.getTotal() < 15000)
            {
                rankArray[9] = 2;
            }
            else if (Result.getTotal() < 15000)
            {
                rankArray[9] = 3;
            }
        }
        Debug.Log(charaArray[9]);
        Debug.Log(scoreArray[9]);
        Debug.Log(stageArray[9]);
        Debug.Log(starArray[9]);
        Debug.Log(rankArray[9]);

        PlayerPrefsX.SetIntArray("score", scoreArray);
        PlayerPrefsX.SetIntArray("chara", charaArray);
        PlayerPrefsX.SetStringArray("stage", stageArray);
        PlayerPrefsX.SetIntArray("star", starArray);
        PlayerPrefsX.SetIntArray("rank", rankArray);
    }
}
