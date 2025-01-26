using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Website : MonoBehaviour
{
    public timerScript timer;
    public HotTrendBehavior hotTrendBehavior;
    public beanKounter money;
    public float trendMulti;
    public float baseValue;
    public string urlID;
    string[] trends;

    void Start()
    {
        baseValue = 0.001f;
        trends = DomainStorage.getBoughtDomainInfoFromID(urlID).Value.trends;
        for (int i = 0; i < trends.Length; i++)
        {
            trendMulti = getTop3Mult(trends);
        }

        timer = GameObject.FindWithTag("Timer").GetComponent<timerScript>();
    }

    void FixedUpdate()
    {
        if ((int)timer.getTimeElapsed() % 15 == 0)
        {
            if (timer.getStartGame())
            {
                float trendVal = 0;
                for (int i = 0; i < trends.Length; i++)
                {
                    trendVal = getTop3Mult(trends);
                }
                Debug.Log(trendVal);
                playerMoneyHandler.PlayerMoney += baseValue * trendVal;
            }
        }
    }

    public float getTop3Mult(string[] trends)
    {
        Debug.Log(DomainStorage.HotTrends[0]);
        Debug.Log(DomainStorage.HotTrends[1]);
        Debug.Log(DomainStorage.HotTrends[2]);
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
