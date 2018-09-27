using UnityEngine;
using System.Collections;

public class FadeScript2 : MonoBehaviour
{

    public GameObject obj;

    // Use this for initialization
    void Start()
    {
    }
    public void MoveUp()
    {

        iTween.MoveTo(gameObject, iTween.Hash("y", 480, "time", 1.5));
    }
    public void MoveDown()
    {

        iTween.MoveTo(gameObject, iTween.Hash("y", -500, "time", 1));
    }
}