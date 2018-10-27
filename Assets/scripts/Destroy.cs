using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        {
           
            Destroy(this.gameObject);
        }
    }

    public void Des()
    {
        Destroy(this.gameObject);
    }
}