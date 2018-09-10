using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createobj: MonoBehaviour {

    public GameObject obj; // 生成するオブジェクト

    public int createNumbers; // 生成する数
    public int space; // 生成する間隔
    public Vector3 createPos; // 生成する場所

    // Use this for initialization
    void Start()
    {
        CreateObject(); // 生成メソッド実行
    }

    // 生成メソッド
    void CreateObject()
    {
        for (int i = 0; i < createNumbers; i++)
        {
            Instantiate(obj, createPos + new Vector3(i + space * i, 0, 0), Quaternion.identity);
        }
    }
}
