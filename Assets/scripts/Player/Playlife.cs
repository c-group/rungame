using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playlife : MonoBehaviour {
    public GameObject lifePrefab;
    public int defaultLife = 3;
    private int life;
    private List<GameObject> lifeList = new List<GameObject>();
    private Vector3 pos;
    void Start()
    {
        life = defaultLife;
        for (int i = 0; i < life; ++i)
        {
            
            lifeList.Add((GameObject)Instantiate(lifePrefab, new Vector3(-40f + i * 5f, 25f, 3f), Quaternion.identity));
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "life")
        {
            ++life;
            Instantiate(lifeList[life]);
        }
        if (col.gameObject.tag=="Enemy")
        { 
            --life;
            Destroy(lifeList[life]);
            lifeList.RemoveAt(life);

            if (life==0)
            {
                SceneManager.LoadSceneAsync("Game Over");
            }
        }
    }
 }
