using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yari : MonoBehaviour
{
    
    GameObject player;
    public float distance;
    private int i = 0;
    private Vector3 playerpos;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerpos = player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 enemypos = this.GetComponent<Transform>().position;
        float dis = Vector3.Distance(playerpos, enemypos);

        if (dis < distance)
        {
            Force();
        }
    }

    void Force()
    {
        while(i < 1){
            this.transform.position += new Vector3(0, 10, 0);
            i++;
        }
        
    }
}
