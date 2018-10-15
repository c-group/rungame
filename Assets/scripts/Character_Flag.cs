using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Flag : MonoBehaviour {


    public static int Soldier = 0;
    public static int Priest = 0;
    public static int Wizard = 0;

    public bool soldier;
    public bool priest;
    public bool wizard;

    private void Start()
    {
        if (soldier)
        {
            SoldierFlag();
        }
        else if (priest)
        {
            PriestFlag();
        }
        else if (wizard)
        {
            WizardFlag();
        }
    }

    public void SoldierFlag()
    {
        Soldier++;
    }

    public void PriestFlag()
    {
        Priest++;
    }

    public void WizardFlag()
    {
        Wizard++;
    }

    public static int GetS_Flag()
    {
        return Soldier;
    }

    public static int GetP_Flag()
    {
        return Priest;
    }

    public static int GetW_Flag()
    {
        return Wizard;
    }

    public void SetReset()
    {
        Soldier = 0;
        Priest = 0;
        Wizard = 0;
    }


}
