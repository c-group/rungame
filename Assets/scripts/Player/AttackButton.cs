using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class AttackButton : UIBehaviour
{

    public GameObject Player_Sound;
    public float wait = 0.5f;

    PlayerSound script;

    protected override void Start()
    {
        base.Start();
        script = Player_Sound.GetComponent<PlayerSound>();

        // Buttonクリック時、OnClickメソッドを呼び出す
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        script.AttackSound();
        StartCoroutine("Push_wait");
    }

    IEnumerator Push_wait()
    {
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(wait); // とりあえず５秒
        GetComponent<Button>().interactable = true;       
    }
}
