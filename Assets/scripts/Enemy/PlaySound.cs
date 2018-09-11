using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {
    Animator anim;
    private AudioSource sound01;
    
    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        sound01 = GetComponent<AudioSource>();
        anim = GetComponent("Animator") as Animator;
    }

    // Update is called once per frame
    void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("damage"))
        {
            sound01.PlayOneShot(sound01.clip);
        }
        
    }
}
