using UnityEngine;
using System.Collections;

public class Priest : MonoBehaviour
{

    // 変数の定義と初期化
    public float flap = 30f;
    public float scroll = 4f;
    Rigidbody2D rb2d;
    Animator anim;
    AnimatorStateInfo animatorStateInfo;
    private new Renderer renderer;
    int jumpCount = 0;

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

        // スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 0)
        {
            // 落下速度をリセット
            rb2d.velocity = Vector2.zero;
            // (0,1)方向に瞬間的に力を加えて跳ねさせる
            rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            jumpCount++;
            anim.SetBool("Jump", true);
            anim.SetBool("Ground", false);

            if (Input.GetKey(KeyCode.S) && anim.GetCurrentAnimatorStateInfo(0).IsName("Priest_jump") == true)
            {
                anim.SetBool("Attack", true);
            }

        }
        else
        {
            anim.SetBool("Jump", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Priest_jump") == true && Input.GetKeyDown(KeyCode.Space) && jumpCount == 1)
        {
            // 落下速度をリセット
            rb2d.velocity = Vector2.zero;
            // (0,1)方向に瞬間的に力を加えて跳ねさせる
            rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            jumpCount++;
            anim.SetBool("Jump2", true);
            anim.SetBool("Ground", false);

            if (Input.GetKey(KeyCode.S) && anim.GetCurrentAnimatorStateInfo(0).IsName("Priest_jump2") == true)
            {
                anim.SetBool("Attack", true);
            }
        }
        else
        {
            anim.SetBool("Jump2", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        anim.Update(0);
        animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);



        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") == true)
            {

                Rigidbody2D rigit = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rigit)
                {
                    rigit.AddForce(transform.root.right * 45, ForceMode2D.Impulse);
                }
            }
            else
            {
                anim.SetTrigger("Damage");
                StartCoroutine("Damage");

            }
        }

    }

    IEnumerator Damage()
    {
        //レイヤーをPlayerDamageに変更
        gameObject.layer = 9;
        //while文を10回ループ
        int count = 10;
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
        //レイヤーをPlayerに戻す
        gameObject.layer = 8;
    }
}

/* tesut lllaaa*/