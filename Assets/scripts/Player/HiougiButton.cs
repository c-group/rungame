using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class HiougiButton : UIBehaviour
{
    private int star;

    protected override void Start()
    {
        base.Start();
        // Buttonクリック時、OnClickメソッドを呼び出す
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void Update()
    {
        star = Score.getStar();
        if (star < 20)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    void OnClick()
    {
        FindObjectOfType<Score>().setStar();
    }
}
