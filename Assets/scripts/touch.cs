using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class touch : MonoBehaviour
{
    public GameObject lifePrefab;

    // 変数の定義と初期化
    public float flap = 30f;
    public float flap2 = 30f;
    public float scroll = 4f;
    Rigidbody2D rb2d;
    Animator anim;
    AnimatorStateInfo animatorStateInfo;
    private new Renderer renderer;
    int jumpCount = 0;
    // SoldierAttackプレハブ
    public GameObject attack;

    // Updateの前に1回だけ呼ばれるメソッド
    void Start()
    {
        // Rigidbody2Dをキャッシュする
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent("Animator") as Animator;

    }
    // Update is called once per frame
    void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {  
            // 落下速度をリセット
            rb2d.velocity = Vector2.zero;
            // (0,1)方向に瞬間的に力を加えて跳ねさせる
            rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            jumpCount++;
            anim.SetBool("Jump", true);
            anim.SetBool("Ground", false);
        }
    }
}
