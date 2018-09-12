using UnityEngine;
using System.Collections;

/// <summary>
/// InvokeRepeating関数を使った、一定時間ごとにオブジェクトを生成するクラス
/// </summary>
public class ObjectCreater3 : MonoBehaviour
{
    /// <summary>
    /// privateな変数をインスペクターから設定できるようにする
    /// </summary>
    [SerializeField]
    /// <summary>
    /// プレハブ
    /// </summary>
    private GameObject prefab;
    /// <summary>
    /// 待ち時間
    /// </summary>
    private float waitingTime = 4f;
    /// <summary>
    /// 初期化
    /// </summary>
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
        Instantiate(prefab, new Vector3(145, 70, -2), Quaternion.identity);
    }
}