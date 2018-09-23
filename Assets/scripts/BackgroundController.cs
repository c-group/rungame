using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    public float speed = 0f;

    void FixedUpdate()
    {
        float scroll = Mathf.Repeat(Time.time * speed, 1);
        Vector2 offset = new Vector2(scroll, 0);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

}