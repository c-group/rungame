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
        int s_jumpcount = Soldier.GetJumpCount();
        int p_jumpcount = Priest.GetJumpCount();
        int w_jumpcount = Wizard.GetJumpCount();

        if (s_jumpcount == 1 || p_jumpcount == 1 || w_jumpcount == 1)
        {
            audioSource.PlayOneShot(audioClip[0]);
        }

        if (s_jumpcount == 2 || p_jumpcount == 2 || w_jumpcount == 2)
        {
            audioSource.PlayOneShot(audioClip[1]);
        }

    }

    public void AttackSound()
    {
        audioSource.PlayOneShot(audioClip[2]);        
    }

    public void DamageSound()
    {
        audioSource.PlayOneShot(audioClip[3]);
    }

    public void DethSound()
    {
        audioSource.PlayOneShot(audioClip[4]);
    }

    public void StarSound()
    {
        audioSource.PlayOneShot(audioClip[5]);
    }
}