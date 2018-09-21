using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "PlayerDamage"))
        {
            Destroy(gameObject);
        }
    }

}
