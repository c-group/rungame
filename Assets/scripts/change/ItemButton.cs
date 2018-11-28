using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ItemButton : UIBehaviour
{
    protected override void Start()
    {
        base.Start();

        // Buttonクリック時、OnClickメソッドを呼び出す
        GetComponent<Button>().onClick.AddListener(OnClick);


    }

    void OnClick()
    {
        FadeManager.Instance.LoadScene("item", 1.0f);

    }
}