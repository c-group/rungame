﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{

    float time;//時間を記録する小数も入る変数.
    Text text;

    void Start()
    {
        time = 0;
        text = GetComponent<Text>();//自分のインスペクター内からTextコンポーネントを取得.
    }

    void Update()
    {
        time += Time.deltaTime*4;//毎フレームの時間を加算.

        int second = (int)time;//秒.timeを60で割った余り.
        string secText;//テキスト形式の分・秒を用意.
     
      
     
            secText = second.ToString();

        text.text =  secText+"m";
    }
}