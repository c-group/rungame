using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    // 変数の定義と初期化
    public float scroll = -0.8f;


    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += new Vector3(scroll, 0, 0);
    }

}
