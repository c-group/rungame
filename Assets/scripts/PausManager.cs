using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausManager : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnClickPaus();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            OnClickReStart();
        }
    }

    public static void OnClickPaus()
    {
        Time.timeScale = 0;
    }

    public static void OnClickReStart()
    {
        Time.timeScale = 1;
    }
}
