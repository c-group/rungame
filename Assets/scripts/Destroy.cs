using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        //衝突判定
      
        {
           
            Destroy(this.gameObject);
        }
    }
}