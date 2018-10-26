using UnityEngine;
using System.Collections;

public class Priest : MonoBehaviour
{

    // 変数の定義と初期化
    public float flap = 30f;
    public float flap2 = 30f;
    public float wait = 4f;
    Rigidbody2D rb2d;
    static Animator anim;
    AnimatorStateInfo animatorStateInfo;
    private new Renderer renderer;
    public static int jumpCount = 0;
    // SoldierAttackプレハブ
    public GameObject attack;
    public GameObject hiougi;
    public GameObject Player_Sound;
    PlayerSound script;
    private int life;

    // Updateの前に1回だけ呼ばれるメソッド
    void Start()
    {
        // Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent("Animator") as Animator;
        script = Player_Sound.GetComponent<PlayerSound>();
        anim.Update(0);
        animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);

    }

    private void Update()
    {

        //スペースキーでジャンプ処理へ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickjump();
        }
        //Sキーで攻撃処理へ
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnClickattack();
        }
        //Aキーで必殺技処理へ
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnClickHiougi();
        }

        if (anim.GetBool("Finish"))
        {
            anim.SetBool("Finish", false);
        }
        //残りライフ数の取得
        life = FindObjectOfType<Playlife>().getLife();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ジャンプカウント
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            anim.SetBool("Jump", false);
        }

        //被ダメージ処理へ
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("Damage");
            StartCoroutine("Damage");
        }
        //星取得
        if (collision.gameObject.tag == "Star")
        {
            script.StarSound();
            FindObjectOfType<Score>().AddStar();
        }
    }

    //ジャンプ処理
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
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Run") || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") || anim.GetCurrentAnimatorStateInfo(0).IsName("Jump")) && jumpCount == 1)
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

    //攻撃処理
    public void OnClickattack()
    {
        anim.SetTrigger("Attack");
        anim.SetBool("Jump", false);
        Instantiate(attack);
    }

    //被ダメージ処理
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
        if (life > 0)
        {
            gameObject.layer = 8;
        }
    }

    //ジャンプカウントを返すゲッター
    public static int GetJumpCount()
    {
        return jumpCount;
    }

    //アニメーターのジャンプステートをfalseにする
    void Jump_false()
    {
        anim.SetBool("Jump", false);
    }

    //アニメーターのFinishトリガーをonにする
    public void Finish()
    {
        anim.SetBool("Finish",true);
    }

    //必殺技処理
    public void OnClickHiougi()
    {

        FindObjectOfType<PausManager>().OnClickPaus();
        anim.SetBool("Hiougi",true);
        Instantiate(hiougi);
        script.HiougiSound();
        FindObjectOfType<FadeController>().Set_Out();
    }

    //アニメーターのHiougiステートをfalseにする
    public void Redy()
    {
        anim.SetBool("Hiougi", false);
    }

    //秘奥義ボイス
    public void H_Attack()
    {
        script.HiougiSound2();
    }

}