using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class playerMoneyHandler
{
    private static float mPlayerMoney = 1.0f;
    
    public static float PlayerMoney
    {
        get { return mPlayerMoney; }
        set { mPlayerMoney = value; }
    }
}
