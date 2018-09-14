using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();

    Animator anim;

    void Start()
    {
        anim = GetComponent("Animator") as Animator;
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    public void JumpSound()
    {
        int jumpcount = Soldier.GetJumpCount();
        if (jumpcount == 1)
        {
            audioSource.PlayOneShot(audioClip[0]);
        }

        if (jumpcount == 2)
        {
            audioSource.PlayOneShot(audioClip[1]);
        }

    }

    public void S_AttackSound()
    {
        audioSource.PlayOneShot(audioClip[2]);
        
    }
}