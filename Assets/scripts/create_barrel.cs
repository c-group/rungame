using UnityEngine;
using System.Collections;

/// <summary>
/// InvokeRepeating関数を使った、一定時間ごとにオブジェクトを生成するクラス
/// </summary>
public class create_barrel : MonoBehaviour
{
    /// <summary>
    /// privateな変数をインスペクターから設定できるようにする
    /// </summary>
    [SerializeField]
    /// <summary>
    /// プレハブ
    /// </summary>
    public GameObject[] Train;
    /// <summary>
    /// 待ち時間
    /// </summary>
    public float waitingTime;
    /// <summary>
    /// 初期化
    /// </summary>
    /// 
    public int x;
    public int y;
    public int rx;
    public int ry;
    public int rz;

    void Awake()
    {
        // InvokeRepeating("関数名",初回呼出までの遅延秒数,次回呼出までの遅延秒数)
        InvokeRepeating("Create", waitingTime, Random.Range(15f,30f));
    }
    /// <summary>
    /// オブジェクトの生成
    /// </summary>
    void Create()
    {
        // インスタンス生成
        Instantiate(Train[Random.Range(0, Train.Length)], new Vector3(x, y, 8), Quaternion.Euler(rx, ry, rz));
    }
}