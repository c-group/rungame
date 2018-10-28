using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rankin : MonoBehaviour {
    
    Image rankinImage;

    // Use this for initialization
    void Start () {
        rankinImage = GetComponent<Image>();
        rankinImage.enabled = false;
    }

    public void rankin()
    {
        rankinImage.enabled = true;
    }

}
