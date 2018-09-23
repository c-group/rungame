using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikazuti : MonoBehaviour {

    Animator anim;
    AnimatorStateInfo animatorStateInfo;

    // Use this for initialization
    void Start () {
        PausManager.OnClickReStart();
        anim = GetComponent("Animator") as Animator;
        anim.Update(0);
        animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Destroy(gameObject);
        }

    }
}
