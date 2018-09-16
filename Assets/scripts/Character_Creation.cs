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
        int SoldierFlag = Character_Flag.GetS_Flag();
        int PriestFlag = Character_Flag.GetP_Flag();
        int WizardFlag = Character_Flag.GetW_Flag();

        if(SoldierFlag == 1)
        {
            Instantiate(Soldier);        
        }
        else if (PriestFlag == 1)
        {
            Instantiate(Priest);
        }
        else if (WizardFlag == 1)
        {
            Instantiate(Wizard);
        }
    }


}
