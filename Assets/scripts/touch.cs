using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touch : UIBehaviour
{
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
        GetComponent<Button>().onClick.AddListener(onClick);

    }
    void onClick()
    {

        // スペースキーが押されたらジャンプ
        
            // 落下速度をリセット
            rb2d.velocity = Vector2.zero;
            // (0,1)方向に瞬間的に力を加えて跳ねさせる
            rb2d.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
            jumpCount++;
            anim.SetBool("Jump", true);
            anim.SetBool("Ground", false);

           
       

        //2段ジャンプ
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") == true &&  jumpCount == 1)
        {
            // 落下速度をリセット
            rb2d.velocity = Vector2.zero;
            // (0,1)方向に瞬間的に力を加えて跳ねさせる
            rb2d.AddForce(Vector2.up * flap2, ForceMode2D.Impulse);
            jumpCount++;
            anim.SetBool("Jump2", true);
            anim.SetBool("Ground", false);

           
        }
        else
        {
            anim.SetBool("Jump2", false);
        }

       

  



    }
}
    
    
    
   
      


