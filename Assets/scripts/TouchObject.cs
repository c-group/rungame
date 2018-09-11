using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour;
    public void OnPointerClick
    {
        // タップされた時の処理をここに書いていきます
        Debug.Log("TOUCH:" + this.name);
    }
}