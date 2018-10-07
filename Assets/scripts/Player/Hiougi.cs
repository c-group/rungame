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
        if (ikazuti) {
            PausManager.OnClickReStart();
        }        
        anim = GetComponent("Animator") as Animator;
        anim.Update(0);
        animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            if (ikazuti)
            {
                Destroy(gameObject);
            }
            else if(rengeki){
                PausManager.OnClickReStart();
                Destroy(gameObject,1);
            }
            
        }

    }

    void FadeIn()
    {
        FindObjectOfType<FadeController>().Set_In();
    }
}
