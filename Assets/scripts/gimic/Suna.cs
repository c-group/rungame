using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Suna : MonoBehaviour {

    /// <summary>
    /// privateな変数をインスペクターから設定できるようにする
    /// </summary>
    [SerializeField]
    /// <summary>
    /// プレハブ
    /// </summary>
    private GameObject prefab;
    private GameObject obj;
    /// <summary>
    /// 待ち時間
    /// </summary>
    public float waitingTime;
    /// <summary>
    /// 初期化
    /// </summary>
    /// 

    float fadeSpeed = 0.015f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;
    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    public float alpha = 0.8f;

    Image fadeImage;

    void Awake()
    {
        // InvokeRepeating("関数名",初回呼出までの遅延秒数,次回呼出までの遅延秒数)
        InvokeRepeating("Create", waitingTime, waitingTime);
    }
    /// <summary>
    /// オブジェクトの生成
    /// </summary>
    void Create()
    {
        // インスタンス生成
        Instantiate(prefab);
        isFadeOut = true;
    }

    // Use this for initialization
    void Start ()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }
    void Update()
    {
        obj = GameObject.Find("sunaarashi(Clone)");

        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
        if (alfa <= 0)
        {                    //c)完全に透明になったら処理を抜ける
            isFadeIn = false;
            fadeImage.enabled = false;    //d)パネルの表示をオフにする
            Destroy(obj);
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alfa += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        if (alfa >= alpha)
        {             // d)完全に不透明になったら処理を抜ける
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    public void Set_In()
    {
        isFadeIn = true;
    }
}
