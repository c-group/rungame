using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private AudioSource sound01;
    private int count = 0;

    void Start()
    {
        sound01 = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(count < 1)
            {
                int life = FindObjectOfType<Playlife>().getLife();
                if (life > 0)
                {
                    FadeManager.Instance.LoadScene("Game Over", 1f);
                    sound01.PlayOneShot(sound01.clip);
                    count++;
                }
            }            
        }
    }
}
