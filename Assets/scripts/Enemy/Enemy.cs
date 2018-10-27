using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // 変数の定義と初期化
    public float scroll = -0.5f;
    public int hp = 1;
    // スコアのポイント
    public int point = 100;
    
    Rigidbody2D rb2d;
    Animator anim;
    public GameObject[] star;
    GameObject player;
    private Vector3 playerpos;

    // Updateの前に1回だけ呼ばれるメソッド
    void Start()
    {
        // Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent("Animator") as Animator;
        player = GameObject.FindGameObjectWithTag("Player");
        playerpos = player.transform.position;
    }

    // シーン中にフレーム毎に呼ばれるメソッド
    void FixedUpdate()
    {
        this.transform.position += new Vector3(scroll, 0, 0);

        //プレイヤーと敵の距離
        Vector3 enemypos = this.GetComponent<Transform>().position;
        float dis = Vector3.Distance(playerpos, enemypos);
        if (dis < 20)
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
    
        if (hp > 0)
        {
            if (collision.gameObject.tag == "Attack")
            {
                StartCoroutine("Deth");
            }
        }

        if (collision.gameObject.tag == "Hiougi")
        {
            StartCoroutine("Deth_2");
        }

        if (collision.gameObject.tag == "Bom")
        {
            StartCoroutine("Deth_3");
        }

        if (collision.gameObject.tag == "Ground")
        {
            rb2d.velocity = Vector2.zero; 
        }
    }
    
    IEnumerator Deth()
    {
        int count = 5;
        anim.SetTrigger("Damage");
        //プレイヤーの攻撃のオブジェクト，コンポーネントを取得
        GameObject attack = GameObject.FindGameObjectWithTag("Attack");
        Attack power = attack.GetComponent<Attack>();

        hp = hp - power.power;
        
        if (hp <= 0)
        {
            anim.SetBool("Down", true);
            int number = Random.Range(0, star.Length);
            Instantiate(star[number], transform.position, transform.rotation);
            gameObject.layer = 13;
            // スコアコンポーネントを取得してポイントを追加
            if (FindObjectOfType<Score_Counter>().GetItem())
            {
                FindObjectOfType<Score>().AddPoint(point*2);
            }
            else
            {
                FindObjectOfType<Score>().AddPoint(point);
            }
           
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

    IEnumerator Deth_2()
    {
        int count = 5;
        anim.SetBool("Down", true);
        int number = Random.Range(0, star.Length);
        Instantiate(star[number], transform.position, transform.rotation);
        gameObject.layer = 13;
        // スコアコンポーネントを取得してポイントを追加
        FindObjectOfType<Score>().AddPoint(point*3);
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

    IEnumerator Deth_3()
    {
        int count = 5;
        anim.SetBool("Down", true);
        int number = Random.Range(0, star.Length);
        Instantiate(star[number], transform.position, transform.rotation);
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

}
