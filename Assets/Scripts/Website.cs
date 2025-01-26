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
    public float initialTrendVal;
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
            initialTrendVal = getTop3Mult(trends);
        }

        timer = GameObject.FindWithTag("Timer").GetComponent<timerScript>();

        mSellButton.onClick.AddListener(sellWebsite);
        mSellText.text = "Website Value: $" + siteProfits.ToString("0.00");
    }

    void FixedUpdate()
    {
        if ((int)timer.getTimeElapsed() % 5 == 0)
        {
            if (timer.getStartGame())
            {
                float trendVal = 0;
                for (int i = 0; i < trends.Length; i++)
                {
                    trendVal = getTop3Mult(trends);
                }

                siteProfits += baseValue * trendVal * initialTrendVal;
                mSellText.text = "Website Value: $" + siteProfits.ToString("0.00");
            }
        }
    }

    public float getTop3Mult(string[] trends)
    {
        float trendVal = 1f;
        foreach (string trend in trends)
        {
            if (DomainStorage.HotTrends[0] == trend)
            {
                trendVal += 3f;
            }
            else if (DomainStorage.HotTrends[1] == trend)
            {
                trendVal += 2f;
            }
            else if (DomainStorage.HotTrends[2] == trend)
            {
                trendVal += 1.5f;
            }
        }

        return trendVal;
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
