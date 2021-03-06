﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiougi : MonoBehaviour {

    Animator anim;
    AnimatorStateInfo animatorStateInfo;

    public bool ikazuti;
    public bool rengeki;

    // Use this for initialization
    void Start () {
        anim = GetComponent("Animator") as Animator;
        anim.Update(0);
        animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            FindObjectOfType<PausManager>().OnClickReStart();
            Destroy(gameObject,1);               
            if(Character_Flag.GetP_Flag() == 1)
            {
                FindObjectOfType<Priest>().Finish();
            }
            else if (Character_Flag.GetW_Flag() == 1)
            {
                FindObjectOfType<Wizard>().Finish();
            }
        }

    }

    void FadeIn()
    {
        FindObjectOfType<FadeController>().Set_In();
    }
}
