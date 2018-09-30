using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiScore_Manager : MonoBehaviour {

    int[] scoreArray = new int[10];
    int[] charaArray = new int[10];
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

        public ScoreRank(int chara, int score, string stage)
        {
            this.chara = chara;
            this.score = score;
            this.stage = stage;
        }
    }

    // Use this for initialization
    void Start () {
        
        int SoldierFlag = Character_Flag.GetS_Flag();
        int PriestFlag = Character_Flag.GetP_Flag();
        int WizardFlag = Character_Flag.GetW_Flag();

        int AlibeonFlag = Stage_Flag.GetAlibeon();
        int FilandFlag = Stage_Flag.GetFiland();
        int RobelFlag = Stage_Flag.GetRobel();
        int LeebleFlag = Stage_Flag.GetLeeble();
        int VareruFlag = Stage_Flag.GetVareru();

        if(AlibeonFlag == 1)
        {
            stagename = "アリベオン山地";
        }

        if (SoldierFlag == 1)
        {
            chara = 0;
        }
        else if (PriestFlag == 1)
        {
            chara = 1;
        }
        else if (WizardFlag == 1)
        {
            chara = 2;
        }

        scoreArray = PlayerPrefsX.GetIntArray("score", 0, 10);
        charaArray = PlayerPrefsX.GetIntArray("chara", 0, 10);
        stageArray = PlayerPrefsX.GetStringArray("stage", "nul", 10);

        for (int i = 0; i < 10; i++)
        {
            sr.Add(new ScoreRank( charaArray[i],scoreArray[i], stageArray[i]));
        }
        sr.Sort((a, b) => b.score.CompareTo(a.score));

        for(int s = 0; s < 10; s++)
        {
            charaArray[s] = sr[s].chara;
            scoreArray[s] = sr[s].score;
            stageArray[s] = sr[s].stage;
        }
        sr.Clear();
    }

    public void Save()
    {
        
        if (Result.getTotal() > scoreArray[9])
        {
            charaArray[9] = chara;
            scoreArray[9] = Result.getTotal();
            stageArray[9] = stagename;
        }
        Debug.Log(charaArray[9]);
        Debug.Log(scoreArray[9]);
        Debug.Log(stageArray[9]);

        PlayerPrefsX.SetIntArray("score", scoreArray);
        PlayerPrefsX.SetIntArray("chara", charaArray);
        PlayerPrefsX.SetStringArray("stage", stageArray);
    }
}
