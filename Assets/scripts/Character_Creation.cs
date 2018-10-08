using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Creation : MonoBehaviour {

    public GameObject Soldier;
    public GameObject Priest;
    public GameObject Wizard;

    // Use this for initialization
    void Start()
    {
        if(Character_Flag.GetS_Flag() == 1)
        {
            Instantiate(Soldier);        
        }
        else if (Character_Flag.GetP_Flag() == 1)
        {
            Instantiate(Priest);
        }
        else if (Character_Flag.GetW_Flag() == 1)
        {
            Instantiate(Wizard);
        }
    }


}
