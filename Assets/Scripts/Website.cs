using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Website : MonoBehaviour
{
    public timerScript timer;
    public HotTrendBehavior hotTrendBehavior;
    public beanKounter money;
    float trendMulti;
    float baseValue;

    void Start()
    {
        baseValue = 0.1f;
    }

    void Update()
    {
        if ((int)timer.getTimeElapsed() % 10 == 0)
        {
            if (timer.getStartGame())
            {
                baseValue *= getTop3Mult(hotTrendBehavior.GetHotTrends());
                money.addMonee(baseValue);
            }
        }
    }

    public float getTop3Mult(string[] trends)
    {
        trendMulti = 1f;
        foreach (string trend in trends)
        {
            if (DomainStorage.HotTrends[0] == trend)
            {
                trendMulti += 3f;
            }
            else if (DomainStorage.HotTrends[1] == trend)
            {
                trendMulti += 2f;
            }
            else if (DomainStorage.HotTrends[2] == trend)
            {
                trendMulti += 1.5f;
            }
        }

        return trendMulti;
    }
}
