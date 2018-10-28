using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yari : MonoBehaviour
{
    
    GameObject player;
    public float distance;
    private int i = 0;
    private int n = 0;
    private Vector3 playerpos;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(count < 1)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerpos = player.transform.position;
            count++;
        }
        
        Vector3 enemypos = this.GetComponent<Transform>().position;
        float dis = Vector3.Distance(playerpos, enemypos);

        if (dis < distance)
        {
            Force();
        }

        if(enemypos.x < playerpos.x && dis > distance)
        {
            Down();
        }
    }

    void Force()
    {
        while(i < 1){
            audioSource.PlayOneShot(audioClip[0]);
            this.transform.position += new Vector3(0, 10, 0);
            i++;
            n = 0;
        }        
    }

    void Down()
    {
        while (n < 1)
        {
            this.transform.position += new Vector3(0, -10, 0);
            n++;
            i = 0;
        }
    }
}
