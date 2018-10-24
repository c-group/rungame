using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class HiougiButton : UIBehaviour
{
    private int star;
    public GameObject fire;
    private int i = 0;

    protected override void Start()
    {
        base.Start();
        // Buttonクリック時、OnClickメソッドを呼び出す
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void Update()
    {
        star = Score.getStar();
        GameObject obj = GameObject.Find("firering(Clone)");
        if (star < 15)
        {
            GetComponent<Button>().interactable = false;
            Destroy(obj);
            i = 0;
        }
        else
        {
            GetComponent<Button>().interactable = true;
            firering();
        }
    }

    void OnClick()
    {
        FindObjectOfType<Score>().setStar();
    }

    void firering()
    {
        while (i < 1)
        {
            Instantiate(fire);
            i++;
        }
        
    }
}
