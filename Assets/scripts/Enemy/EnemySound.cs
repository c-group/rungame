using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();

    Animator anim;

    public float volume;

    void Start()
    {
        anim = GetComponent("Animator") as Animator;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("damage"))
        {
            audioSource.PlayOneShot(audioClip[0]);
            audioSource.volume = volume;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("down"))
        {
            audioSource.PlayOneShot(audioClip[1]);
            audioSource.volume = 1f;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            audioSource.PlayOneShot(audioClip[2]);
            audioSource.volume = volume;
        }


    }
}
