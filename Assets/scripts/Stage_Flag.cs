using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Flag : MonoBehaviour {

    public static int alibeon;
    public static int filand;
    public static int robel;
    public static int leeble;
    public static int vareru;

    public void Alibeon_Flag()
    {
        alibeon++;
    }

    public void Filand_Flag()
    {
        filand++;
    }

    public void Robel_Flag()
    {
        robel++;
    }

    public void Leeble_Flag()
    {
        leeble++;
    }

    public void Vareru_Flag()
    {
        vareru++;
    }

    public static int GetAlibeon()
    {
        return alibeon;
    }

    public static int GetFiland()
    {
        return filand;
    }

    public static int GetRobel()
    {
        return robel;
    }

    public static int GetLeeble()
    {
        return leeble;
    }

    public static int GetVareru()
    {
        return vareru;
    }

    public void SetReset()
    {
        alibeon = 0;
        filand = 0;
        robel = 0;
        leeble = 0;
        vareru = 0;
    }


}
