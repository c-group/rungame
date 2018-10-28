using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Needle : MonoBehaviour {

    private int count;
    public float d;
    public float l;

    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(count < 1)
        {
            this.transform.position += new Vector3(l, d, 0);
        }
        else
        {
            this.transform.position += new Vector3(-0.5f, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            count++;
            this.GetComponent<AudioSource>().enabled = true;
        }
    }
}
