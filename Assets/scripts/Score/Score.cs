using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // スコアを表示するText
    public Text scoreText;

    //星テキスト
    public Text starText;

    // スコア
    public static int score;
    private int rankin_score;
    int applay = 0;

    //ステージ情報
    private string stagename;

    //キャラ情報
    int chara;

    //星数
    public static int star = 0;

    // PlayerPrefsで保存するためのキー
    public string CharaKey = "Chara";
    public string ScoreKey = "Score";
    public string StageKey = "Stage";


   
    void Start()
    {
        stagename = SceneManager.GetActiveScene().name;
        int SoldierFlag = Character_Flag.GetS_Flag();
        int PriestFlag = Character_Flag.GetP_Flag();
        int WizardFlag = Character_Flag.GetW_Flag();

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

        Initialize();
    }

    void Update()
    {
       if(score > Score_Ranking.getMin_Score())
        {
            rankin_score = score;
            applay = 1;
        }

        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        starText.text = "×" + star.ToString();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;
        star = 0;
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
        score = score + point;
    }

    public void AddStar()
    {
        star++;
    }


    public void Save()
    {
        if (applay > 1)
        {
            Score_Ranking.set_Score(chara, rankin_score, stagename);
            applay = 0;
        }
        //FindObjectOfType<Score_Ranking>().Save();

    }

    public static int getScore()
    {
        return score;
    }

    public static int getStar()
    {
        return star;
    }

    public static void setStar()
    {
        star -= 20;
    }
}