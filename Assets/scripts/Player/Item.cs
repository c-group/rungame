﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "PlayerDamage"))
        {
            Destroy(gameObject);   
        }
    }
}
