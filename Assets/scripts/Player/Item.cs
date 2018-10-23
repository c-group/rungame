using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public bool heart;
    public bool score;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "PlayerDamage"))
        {
            if (heart)
            {
                Destroy(gameObject);
            }
            else if (score)
            {
                FindObjectOfType<Score_Counter>().SetItem();
                GameObject.Find("bgm").GetComponent<AudioSource>().enabled = false;
                GameObject.Find("Item_Bgm").GetComponent<AudioSource>().enabled = true;
                Destroy(gameObject);
            }
            
        }
    }
}
