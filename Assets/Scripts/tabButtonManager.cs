using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tabButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject tabPrefab;
    [SerializeField] private GameObject _DomainWindow;
    [SerializeField] private GameObject _TrendsWindow;
    [SerializeField] private GameObject _BuyWindow;
    [SerializeField] private GameObject m_WindowDefault;
    [SerializeField] private GameObject m_WindowSpawner;
    public List<Button> purchasedDomains;
    [SerializeField] Button websiteTabTemplate;
    [SerializeField] Canvas canvas;
    private RectTransform tabBarRect;
    private GameObject mCurrWindow;

    private List<GameObject> tabButtons = new List<GameObject>();

    private void OnEnable()
    {
        eventSystem.newTab += addTab;
    }

    // Start is called before the first frame update
    void Start()
    {
        mCurrWindow = _DomainWindow;

        tabBarRect = GetComponent<RectTransform>();
        addTab("Domains", "www.domains.com");
        addTab("Trends", "www.trends.com");
        addTab("Buy", "www.buydomains.com");
        addTab("Buy", "www.buydomaains.com");
        addTab("Buy", "www.buydomasins.com");
        addTab("Buy", "www.buydomasains.com");
        addTab("Buy", "www.buydoamains.com");
        addTab("Buy", "www.buydoasdmains.com");
        addTab("Buy", "www.bsasuydomains.com");
        addTab("Buy", "www.buydoasmains.com");
        addTab("Buy", "www.buydoasmains.com");
        addTab("Buy", "www.buydomsaains.com");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toWebsite()
    {

    }

    //Function to add a new button
    public void addTab(string title, string url)
    {
        GameObject newTab = Instantiate(tabPrefab);
        newTab.GetComponentInChildren<TextMeshProUGUI>().text = title;
        newTab.transform.SetParent(transform);
        RectTransform newTabRect = newTab.GetComponent<RectTransform>();
        Vector2 newTabPos = new Vector2(-(int)(tabBarRect.sizeDelta.x / 2), 0);

        float totalTabLength = 0;
        foreach (GameObject tabOBJ in tabButtons)
        {
            RectTransform tabRect = tabOBJ.GetComponent<RectTransform>();
            totalTabLength += tabRect.sizeDelta.x * tabRect.localScale.x;
        }

        if (totalTabLength > tabBarRect.sizeDelta.x)
        {
            float newWidth = tabBarRect.sizeDelta.x / totalTabLength;

            foreach (GameObject tabOBJ in tabButtons)
            {
                RectTransform tabRect = tabOBJ.GetComponent<RectTransform>();
                tabRect.sizeDelta = new Vector2(tabRect.sizeDelta.x * newWidth, tabRect.sizeDelta.y);

                ////RESIZE BUTTONS AS WELL
            }
        }

        ////REPOSITION THE BUTTONS

        newTabPos += new Vector2(totalTabLength, 0);
        newTabRect.localPosition = newTabPos;
        tabButtons.Add(newTab);

        EventTrigger trigger = newTab.GetComponentInChildren<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { switchWindow((BaseEventData)data); });
        trigger.triggers.Add(entry);

        newTab.GetComponentInChildren<tabScript>().WindowName = url;

        if (url == "www.domains.com")
        {
            DomainStorage.addToWindows(url, _DomainWindow);
        }
        else if (url == "www.trends.com")
        {
            DomainStorage.addToWindows(url, _TrendsWindow);
        }
        else if (url == "www.buydomains.com")
        {
            DomainStorage.addToWindows(url, _BuyWindow);
        }
        else
        {
            GameObject newWindow = Instantiate(m_WindowDefault, m_WindowSpawner.transform);
            DomainStorage.addToWindows(url, newWindow);
        }
    }

    public void switchWindow(BaseEventData eventData)
    {
        GameObject window = DomainStorage.getWindowFromKey(eventData.selectedObject.GetComponent<tabScript>().WindowName);

        mCurrWindow.transform.position = new Vector3(mCurrWindow.transform.position.x, mCurrWindow.transform.position.y, 10); //Move curr window back
        window.transform.position = new Vector3(window.transform.position.x, window.transform.position.y, 0);  //Move new window up
        mCurrWindow = window;
    }
}