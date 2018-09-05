using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour
{

    public GameObject obj;

    // Use this for initialization
    void Start()
    {
    }
    public void MoveUp()
    {
       
     iTween.MoveTo(gameObject, iTween.Hash("y", 1500, "time", 1));
    }
    public void MoveDown()
    {

        iTween.MoveTo(gameObject, iTween.Hash("y", 500, "time", 2));
    }
}