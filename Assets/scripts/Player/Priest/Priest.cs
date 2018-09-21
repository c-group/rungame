using UnityEngine;
using System.Collections;

public class Priest : MonoBehaviour
{

    // 変数の定義と初期化
    public float flap = 30f;
    public float flap2 = 30f;
    public float scroll = 4f;
    Rigidbody2D rb2d;
    Animator anim;
    AnimatorStateInfo animatorStateInfo;
    private new Renderer renderer;
    public static int jumpCount = 0;
    // SoldierAttackプレハブ
    public GameObject attack;
    public GameObject Player_Sound;
    PlayerSound script;

    public bool _touch_flag;      // タッチ有無
    public Vector2 _touch_position;   // タッチ座標
    public TouchPhase _touch_phase;   // タッチ状態


    // Updateの前に1回だけ呼ばれるメソッド
    void Start()
    {
        // Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent("Animator") as Animator;
        script = Player_Sound.GetComponent<PlayerSound>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickjump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            OnClickattack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.Update(0);
        animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        //ジャンプカウント
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            anim.SetBool("Jump", false);
        }

        //被ダメージ処理
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("Damage");
            StartCoroutine("Damage");
        }

        if (collision.gameObject.tag == "Star")
        {
            script.StarSound();
        }

    }

    public void OnClickjump()
    {

        if (jumpCount == 0)
        {
            anim.SetBool("Jump", true);
            // 落下速度をリセット
            rb2d.velocity = Vector2.zero;
            // (0,1)方向に瞬間的に力を加えて跳ねさせる
            rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            jumpCount++;

        }


        //2段ジャンプ
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && jumpCount == 1)
        {
            anim.SetBool("Jump", false);
            anim.SetTrigger("Jump2");
            // 落下速度をリセット
            rb2d.velocity = Vector2.zero;
            // (0,1)方向に瞬間的に力を加えて跳ねさせる
            rb2d.AddForce(Vector2.up * flap2, ForceMode2D.Impulse);
            jumpCount++;

        }


    }

    //攻撃
    public void OnClickattack()
    {
        anim.SetTrigger("Attack");
        // 斬撃をプレイヤーと同じ位置/角度で作成
        Instantiate(attack);
    }



    IEnumerator Damage()
    {
        script.DamageSound();
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

    public static int GetJumpCount()
    {
        return jumpCount;
    }

}