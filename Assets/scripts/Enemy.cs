using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // 変数の定義と初期化
    public float flap = 550f;
    public float scroll = -0.5f;
    public GameObject Player;

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
        Debug.Log(dis);
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            anim.SetTrigger("Damage");
        }
    }



}