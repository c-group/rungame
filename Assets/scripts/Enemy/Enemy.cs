﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // 変数の定義と初期化
    public float flap = 550f;
    public float scroll = -0.5f;
    public GameObject Player;
    public int hp = 1;
    // スコアのポイント
    public int point = 100;

    Rigidbody2D rb2d;
    Animator anim;

    // Updateの前に1回だけ呼ばれるメソッド
    void Start()
    {
        // Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent("Animator") as Animator;
    }

    // シーン中にフレーム毎に呼ばれるメソッド
    void Update()
    {
        this.transform.position += new Vector3(scroll, 0, 0);

        //プレイヤーと敵の距離
        Vector3 playerpos = Player.transform.position;
        Vector3 enemypos = this.GetComponent<Transform>().position;
        float dis = Vector3.Distance(playerpos, enemypos);
        //Debug.Log(dis);
        if (dis < 10)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

    }

    //被ダメージ処理
    void OnCollisionEnter2D(Collision2D collision){
        if(hp > 0)
        {
            if (collision.gameObject.tag == "Attack")
            {
                StartCoroutine("Deth");
            }

        }
        

        if (collision.gameObject.tag == "Ground")
        {
            rb2d.velocity = Vector2.zero; 
        }
    }
    
    IEnumerator Deth()
    {
        int count = 10;
        anim.SetTrigger("Damage");
        //プレイヤーの攻撃のオブジェクト，コンポーネントを取得
        GameObject attack = GameObject.FindGameObjectWithTag("Attack");
        Attack power = attack.GetComponent<Attack>();

        hp = hp - power.power;
        
        if (hp <= 0)
        {
            anim.SetBool("Down", true);
            gameObject.layer = 13;
            // スコアコンポーネントを取得してポイントを追加
            FindObjectOfType<Score>().AddPoint(point);
            while (count > 0)
            {
                //透明にする
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                //0.05秒待つ
                yield return new WaitForSeconds(0.05f);
                //元に戻す
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                //0.05秒待つ
                yield return new WaitForSeconds(0.05f);
                count--;
            }
            Destroy(gameObject);
        }
        else
        {
            while (count > 0)
            {
                //透明にする
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                //0.05秒待つ
                yield return new WaitForSeconds(0.05f);
                //元に戻す
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                //0.05秒待つ
                yield return new WaitForSeconds(0.05f);
                count--;
            }
        }

    }
}
