using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rankin : MonoBehaviour {
    
    Text rankinText;

    // Use this for initialization
    void Start () {
        rankinText = GetComponent<Text>();
        rankinText.enabled = false;
    }

    public void rankin()
    {
        rankinText.enabled = true;
    }

}
