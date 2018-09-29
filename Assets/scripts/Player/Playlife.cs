using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playlife : MonoBehaviour {
    public GameObject lifePrefab;
    public int defaultLife = 3;
    private static int life;
    private List<GameObject> lifeList = new List<GameObject>();
    private Vector3 pos;
    public GameObject Player_Sound;
    PlayerSound script;
    

    void Start()
    {
        script = Player_Sound.GetComponent<PlayerSound>();
        life = defaultLife;
        for (int i = 0; i < life; ++i)
        {
            
            lifeList.Add((GameObject)Instantiate(lifePrefab, new Vector3(-40f + i * 5f, 20f, 3f), Quaternion.identity));
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "life" && life < 3)
        {
            script.HealSound();
            ++life;
            int position = life - 1;
            lifeList.Add((GameObject)Instantiate(lifePrefab, new Vector3(-40f + position * 5f, 20f, 3f), Quaternion.identity));
        }
        else if(col.gameObject.tag == "life")
        {
            script.HealSound();
            FindObjectOfType<Score>().AddPoint(300);
        }

        if (col.gameObject.tag=="Enemy")
        { 
            --life;
            Destroy(lifeList[life]);
            lifeList.RemoveAt(life);

            if (life==0)
            {
                script.DethSound();
                FindObjectOfType<HiScore_Manager>().Save();
                FadeManager.Instance.LoadScene("Game Over", 1.0f);
            }
        }
    }

    public static int  getLife()
    {
        return life;
    }
 }
