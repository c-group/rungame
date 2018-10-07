using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misairu : MonoBehaviour {
    static Animator anim;
    public AudioClip audioClip1;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        anim = GetComponent("Animator") as Animator;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Attack" || collision.gameObject.tag == "Hiougi")
        {
            gameObject.layer = 13;
            anim.SetTrigger("bakuhatu");
            audioSource.Play();
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
