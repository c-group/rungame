using System;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    // スコアを表示するText
    public Text scoreText;

    //星テキスト
    public Text starText;

    // スコア
    public static int score;
 
    //星数
    public static int star = 0;
   
    void Start()
    {
        Initialize();
    }

    void Update()
    {
        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        starText.text = "×" + star.ToString();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;
        star = 20;
    }

    // ポイントの追加
    public void AddPoint(int point)
    {
        score = score + point;
    }

    public void AddPoint2(int point)
    {
        score = score + point*2;
    }

    public void AddStar()
    {
        star++;
    }

    public static int getScore()
    {
        return score;
    }

    public static int getStar()
    {
        return star;
    }

    public void setStar()
    {
        star -= 20;
    }
}