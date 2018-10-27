using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakudan : MonoBehaviour {

    private int count = 0;
    public GameObject Bakuhatu;
    Rigidbody2D rb2d;

    void Start()
    {
        // Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            if (count == 0)
            {
                count++;
                this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            }
            else
            {
                Instantiate(Bakuhatu);
                Destroy(gameObject);
            }
                
        }

        if (collision.gameObject.tag == "Ground")
        {
            rb2d.velocity = Vector2.zero;
        }
    }

}
