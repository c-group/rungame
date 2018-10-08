using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    //　非同期動作で使用するAsyncOperation
    private AsyncOperation async;
    //　シーンロード中に表示するUI画面
    [SerializeField]
    private GameObject loadUI;
    //　読み込み率を表示するスライダー
    [SerializeField]
    private Slider slider;

    public void Retrie()
    {
        if (Stage_Flag.GetAlibeon() == 1)
        {
            Alibeon();
        }
        else if (Stage_Flag.GetFiland() == 1)
        {
            Filand();
        }
        else if (Stage_Flag.GetRobel() == 1)
        {
            Robel();
        }
        else if (Stage_Flag.GetLeeble() == 1)
        {
            Leeble();
        }
        else if (Stage_Flag.GetVareru() == 1)
        {
            Vareru();
        }
    }

    public void Alibeon()
    {
        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);
        
        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("アリベオン山脈"); 

        //　コルーチンを開始
        StartCoroutine("LoadData");
    }

    public void Filand()
    {
        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("フィランド城");

        //　コルーチンを開始
        StartCoroutine("LoadData");
    }

    public void Robel()
    {
        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("ロベル城");

        //　コルーチンを開始
        StartCoroutine("LoadData");
    }

    public void Leeble()
    {
        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("レエブル砂漠");

        //　コルーチンを開始
        StartCoroutine("LoadData");
    }

    public void Vareru()
    {
        //　ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("ヴァール島");

        //　コルーチンを開始
        StartCoroutine("LoadData");
    }

    IEnumerator LoadData()
    {
        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }
    }
}