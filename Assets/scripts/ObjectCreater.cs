using UnityEngine;
using System.Collections;

/// <summary>
/// InvokeRepeating関数を使った、一定時間ごとにオブジェクトを生成するクラス
/// </summary>
public class ObjectCreater : MonoBehaviour
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
    public float waitingTime;
    /// <summary>
    /// 初期化
    /// </summary>
    /// 
    public int x;
    public int y;

    public bool Bom;
    public bool Ice_Needle;

    private AudioSource sound01;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, -45);
        sound01 = GetComponent<AudioSource>();
    }
    void Awake()
    {
        // InvokeRepeating("関数名",初回呼出までの遅延秒数,次回呼出までの遅延秒数)
        if (Bom)
        {
            InvokeRepeating("Create", waitingTime, Random.Range(40f, 70f));
        }
        else if (Ice_Needle)
        {
            InvokeRepeating("Create_I", waitingTime, Random.Range(20f, 40f));
        }
        else
        {
            InvokeRepeating("Create", waitingTime, Random.Range(5f,10f));
        }
        
    }
    /// <summary>
    /// オブジェクトの生成
    /// </summary>
    void Create()
    {
        // インスタンス生成
        Instantiate(prefab, new Vector3(x,y,2), Quaternion.identity);
    }

    void Create_I()
    {
        // インスタンス生成
        Instantiate(prefab, new Vector3(x, y, 2), transform.rotation);
        sound01.PlayOneShot(sound01.clip);
    }
}