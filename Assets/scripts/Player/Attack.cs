using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public int speed = 10;
    public float r_fors = 30f;
    public float u_fors = 30f;
    public int power = 1;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 1;
    public bool priest = false;

    //斬撃飛ばし
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
        // lifeTime秒後に削除
        Destroy(gameObject, lifeTime);
    }

    //敵の吹き飛ばし
    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rigit = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rigit)
        {
            rigit.AddForce(transform.root.right * r_fors, ForceMode2D.Impulse);
            rigit.AddForce(transform.root.up * u_fors, ForceMode2D.Impulse);
        }

        if (priest == false)
        {
            Destroy(gameObject);
        }        
    }

    public int Get_Power()
    {
        return power;
    }
}
