using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Star : MonoBehaviour {

    Rigidbody2D rb2d;
    public int flap_u;
    public int flap_r;

    void Start()
    {
        // Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.zero;
         // (0,1)方向に瞬間的に力を加えて跳ねさせる
        rb2d.AddForce(Vector2.up * flap_u, ForceMode2D.Impulse);
        rb2d.AddForce(Vector2.right * flap_r, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "PlayerDamage"))
        {
            Destroy(gameObject);
        }
    }


}
