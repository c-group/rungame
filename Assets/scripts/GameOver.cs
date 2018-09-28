using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private AudioSource sound01;

    void Start()
    {
        sound01 = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<Score>().Save();
            int life = Playlife.getLife();
            if (life <= 0)
            {
                FadeManager.Instance.LoadScene("Game Over", 1.5f);
            }
            else
            {
                sound01.PlayOneShot(sound01.clip);
                FadeManager.Instance.LoadScene("Game Over", 1.5f);

            }
           
        }
    }
}
