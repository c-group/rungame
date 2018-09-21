using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // スコアを表示するText
    public Text scoreText;

    // ハイスコアを表示するText
    // public Text highScoreText;

    //星テキスト
    public Text starText;

    // スコア
    public static int score;

    // ハイスコア
    // public static int highScore;

    //星数
    private int star = 0;

    // PlayerPrefsで保存するためのキー
   // public string highScoreKey = "highScore";
   
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        // スコアがハイスコアより大きければ
        //if (highScore < score)
        //{
          //  highScore = score;
        //}

        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        //highScoreText.text = "HighScore : " + highScore.ToString();
        starText.text = "×" + star.ToString();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;

        // ハイスコアを取得する。保存されてなければ0を取得する。
       // highScore = PlayerPrefs.GetInt(highScoreKey, 0);
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

    // ハイスコアの保存
    public void Save()
    {
        // ハイスコアを保存する
       // PlayerPrefs.SetInt(highScoreKey, highScore);
        //PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Initialize();
    }

    public static int getScore()
    {
        return score;
    }
}