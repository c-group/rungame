using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mahouzin : MonoBehaviour {

    public float lifeTime = 1;
    public GameObject ikazuti;
    private int i = 0;
    Animator anim;
    AnimatorStateInfo animatorStateInfo;
    public bool priest;
    public bool wizard;

    // Use this for initialization
    void Start() {
        anim = GetComponent("Animator") as Animator;
        anim.Update(0);
        animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);       
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            
            while( i < 1)
            {
                i++;
                Instantiate(ikazuti);
                Destroy(gameObject, lifeTime);
            }
        }        
    }

    private void Redy()
    {
        if (priest)
        {
            Priest.Redy();
        }
        else if (wizard)
        {
            Wizard.Redy();
        }        
    }

}
