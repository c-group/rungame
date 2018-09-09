using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : MonoBehaviour
{

    public int speed = 10;
    public float power = 30f;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 1;

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
            rigit.AddForce(transform.root.right * power, ForceMode2D.Impulse);
        }
    }
}
