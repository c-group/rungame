using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Soldier_JumpButton : UIBehaviour
{

    public GameObject Soldier; 
    public float wait = 1f;
    PlayerSound script;
    Soldier jump;

    private int count = 0;

    protected override void Start()
    {
        base.Start();
        script = Soldier.GetComponent<PlayerSound>();
        GetComponent<Button>().onClick.AddListener(OnClick);

    }

    IEnumerator Push_wait()
    {
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(wait); // とりあえず５秒
        GetComponent<Button>().interactable = true;
        count = 0;
    }

    void OnClick()
    {
        count++;
        // Buttonクリック時、OnClickメソッドを呼び出す
        if (count < 3)
        {
            script.JumpSound();
        }
        else
        {
            StartCoroutine("Push_wait");
        }
        
    }
}