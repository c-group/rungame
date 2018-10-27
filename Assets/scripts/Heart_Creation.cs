using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Creation : MonoBehaviour {
    public GameObject Heart;
    public float timeOut;
    private float timeElapsed;
    public bool score;

    // Update is called once per frame
    void FixedUpdate () {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            if (score)
            {
                float y = Random.Range(4f, 10f);
                Instantiate(Heart, new Vector3(90, y, 2), Quaternion.identity);
                timeElapsed = 0.0f;
                timeOut = Random.Range(40f, 60f);
            }
            else
            {
                float y = Random.Range(4f, 10f);
                Instantiate(Heart, new Vector3(90, y, 2), Quaternion.identity);
                timeElapsed = 0.0f;
                timeOut = Random.Range(20f, 40f);
            }
            
        }
	}
}
