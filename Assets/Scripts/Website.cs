using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Website : MonoBehaviour
{
    [SerializeField] private Button mSellButton;
    [SerializeField] private TextMeshProUGUI mSellText;
    public timerScript timer;
    public HotTrendBehavior hotTrendBehavior;
    public beanKounter money;
    public float trendMulti;
    public float baseValue;
    public string urlID;
    private string[] trends;
    private float siteProfits;

    void Start()
    {
        baseValue = 0.001f;
        trends = DomainStorage.getBoughtDomainInfoFromID(urlID).Value.trends;
        for (int i = 0; i < trends.Length; i++)
        {
            trendMulti = getTop3Mult(trends);
        }

        timer = GameObject.FindWithTag("Timer").GetComponent<timerScript>();

        mSellButton.onClick.AddListener(sellWebsite);
        mSellText.text = "Website Value: $" + siteProfits.ToString("0.00");
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

                siteProfits += baseValue * trendVal;
                mSellText.text = "Website Value: $" + siteProfits.ToString("0.00");
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

    private void sellWebsite()
    {
        GameObject window = DomainStorage.getWindowFromKey("www.domains.com");

        window.transform.position = new Vector3(window.transform.position.x, window.transform.position.y, 0);  //Move new window up
        DomainStorage.CurrWindow = window;

        playerMoneyHandler.PlayerMoney += siteProfits;

        eventSystem.fireEvent(new RemoveTabEvent(DomainStorage.getBoughtDomainInfoFromID(urlID).Value.url));
        Destroy(gameObject);
    }
}
