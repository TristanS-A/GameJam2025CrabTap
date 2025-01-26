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

    void Start()
    {
        baseValue = 0.01f;
        string[] trends = DomainStorage.getBoughtDomainInfoFromID(urlID).Value.trends;
        for (int i = 0; i < trends.Length; i++)
        {
            trendMulti = getTop3Mult(trends);
        }

        timer = GameObject.FindWithTag("Timer").GetComponent<timerScript>();
    }

    void Update()
    {
        if ((int)timer.getTimeElapsed() % 10 == 0)
        {
            if (timer.getStartGame())
            {
                float trendVal = getTop3Mult(DomainStorage.HotTrends);
                Debug.Log(trendVal);
                playerMoneyHandler.PlayerMoney += baseValue * trendVal;
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
