using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class playerMoneyHandler
{
    public static float mStartingMoney = 1.0f;
    private static float mPlayerMoney = mStartingMoney;

    public static float PlayerMoney
    {
        get { return mPlayerMoney; }
        set { mPlayerMoney = value; }
    }

    public static void reset()
    {
        mPlayerMoney = mStartingMoney;
    }
}
