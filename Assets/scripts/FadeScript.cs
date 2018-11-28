using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{

    public GameObject obj;

    public int y1 = 1500;
    public int y2 = 600;
    public float time1 = 1;
    public float time2 = 2;

    public void MoveUp()
    {       
     iTween.MoveTo(gameObject, iTween.Hash("y", y1, "time", time1));
    }

    public void MoveDown()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", y2, "time", time2));
    }
}