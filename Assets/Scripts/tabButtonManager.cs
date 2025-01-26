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
    [SerializeField] private GameObject _ClockWindow;
    [SerializeField] private GameObject m_WindowDefault;
    [SerializeField] private GameObject m_WindowSpawner;
    public List<Button> purchasedDomains;
    [SerializeField] Button websiteTabTemplate;
    [SerializeField] Canvas canvas;
    private RectTransform tabBarRect;

    private List<GameObject> tabButtons = new List<GameObject>();

    private void OnEnable()
    {
        eventSystem.newTab += addTab;
        eventSystem.removeTab += removeTab;
    }

    private void OnDisable()
    {
        eventSystem.newTab -= addTab;
        eventSystem.removeTab -= removeTab;
    }

    // Start is called before the first frame update
    void Start()
    {
        DomainStorage.CurrWindow = _DomainWindow;

        tabBarRect = GetComponent<RectTransform>();
        addTab("Domains", "www.domains.com");
        addTab("Trends", "www.trends.com");
        addTab("Buy", "www.buydomains.com");
        addTab("Clock", "www.clock.com");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toWebsite()
    {

    }

    private float repositionTabs()
    {
        float startPos = (-(int)(tabBarRect.sizeDelta.x / 2));

        for (int i = 0; i < tabButtons.Count; i++)
        {
            RectTransform tabRect = tabButtons[i].GetComponent<RectTransform>();
            tabRect.localPosition = new Vector2(startPos, 0);

            startPos += tabRect.sizeDelta.x * tabRect.localScale.x;
        }

        return 0;
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


        newTabPos += new Vector2(totalTabLength, 0);

        if (tabButtons.Count > 0)
        {
            newTabRect.sizeDelta = new Vector2(tabButtons[0].GetComponent<RectTransform>().sizeDelta.x, newTabRect.sizeDelta.y);

            RectTransform buttonTabRect = newTab.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>();
            buttonTabRect.sizeDelta = new Vector2(tabButtons[0].GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>().sizeDelta.x, buttonTabRect.sizeDelta.y);

            RectTransform buttonTextRect = buttonTabRect.gameObject.GetComponentInChildren<TextMeshProUGUI>().gameObject.GetComponent<RectTransform>();
            RectTransform buttonTextBefore = tabButtons[0].GetComponentInChildren<TextMeshProUGUI>().gameObject.GetComponent<RectTransform>();
            float width = buttonTextRect.sizeDelta.x - buttonTextBefore.sizeDelta.x;
            buttonTextRect.sizeDelta = new Vector2(buttonTextBefore.sizeDelta.x, buttonTextBefore.sizeDelta.y);
            buttonTextRect.localPosition -= new Vector3(width * 0.5f, 0, 0);
        }

        newTabRect.localPosition = newTabPos;
        tabButtons.Add(newTab);

        totalTabLength += newTabRect.sizeDelta.x * newTabRect.localScale.x;

        if (totalTabLength > tabBarRect.sizeDelta.x)
        {
            float newWidth = tabBarRect.sizeDelta.x / totalTabLength;

            foreach (GameObject tabOBJ in tabButtons)
            {
                RectTransform tabRect = tabOBJ.GetComponent<RectTransform>();
                RectTransform buttonTabRect = tabOBJ.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>();
                RectTransform buttonTextRect = buttonTabRect.gameObject.GetComponentInChildren<TextMeshProUGUI>().gameObject.GetComponent<RectTransform>();
                tabRect.sizeDelta = new Vector2(tabRect.sizeDelta.x * newWidth, tabRect.sizeDelta.y);
                buttonTabRect.sizeDelta = new Vector2(buttonTabRect.sizeDelta.x * newWidth, buttonTabRect.sizeDelta.y);

                float width = buttonTextRect.sizeDelta.x;
                buttonTextRect.sizeDelta = new Vector2(buttonTextRect.sizeDelta.x * newWidth, buttonTextRect.sizeDelta.y);
                width = width - buttonTextRect.sizeDelta.x;
                buttonTextRect.localPosition -= new Vector3(width * 0.5f, 0, 0);
            }

            float t = repositionTabs();
        }

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
        else if (url == "www.clock.com")
        {
            DomainStorage.addToWindows(url, _ClockWindow);
        }
        else
        {
            GameObject newWindow = Instantiate(m_WindowDefault, m_WindowSpawner.transform);
            DomainStorage.addToWindows(url, newWindow);
        }
    }

    public void addMoneyMakingTab(string url, float baseVal, float trendVal) 
    {
        addTab(url, url);
    }

    public void removeTab(string url)
    {
        Debug.Log(url);
        float totalTabLength = 0;
        int indexToRemoveAt = -1;
        for (int i = 0; i < tabButtons.Count; i++)
        {
            if (tabButtons[i].GetComponentInChildren<tabScript>().WindowName != url)
            {
                RectTransform tabRect = tabButtons[i].GetComponent<RectTransform>();
                totalTabLength += tabRect.sizeDelta.x * tabRect.localScale.x;
            }
            else
            {
                indexToRemoveAt = i;
            }
        }

        if (indexToRemoveAt != -1)
        {
            GameObject oldTab = tabButtons[indexToRemoveAt];
            tabButtons.RemoveAt(indexToRemoveAt);
            Destroy(oldTab);

            float newWidth = tabBarRect.sizeDelta.x / totalTabLength;

            foreach (GameObject tabOBJ in tabButtons)
            {
                RectTransform tabRect = tabOBJ.GetComponent<RectTransform>();
                RectTransform buttonTabRect = tabOBJ.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>();
                RectTransform buttonTextRect = buttonTabRect.gameObject.GetComponentInChildren<TextMeshProUGUI>().gameObject.GetComponent<RectTransform>();
                tabRect.sizeDelta = new Vector2(tabRect.sizeDelta.x * newWidth, tabRect.sizeDelta.y);
                buttonTabRect.sizeDelta = new Vector2(buttonTabRect.sizeDelta.x * newWidth, buttonTabRect.sizeDelta.y);

                float width = buttonTextRect.sizeDelta.x;
                buttonTextRect.sizeDelta = new Vector2(buttonTextRect.sizeDelta.x * newWidth, buttonTextRect.sizeDelta.y);
                width = buttonTextRect.sizeDelta.x - width;
                buttonTextRect.localPosition += new Vector3(width * 0.5f, 0, 0);
            }

            float t = repositionTabs();
        }
    }

    public void switchWindow(BaseEventData eventData)
    {
        if (eventData.selectedObject != null)
        {
            GameObject window = DomainStorage.getWindowFromKey(eventData.selectedObject.GetComponent<tabScript>().WindowName);

            DomainStorage.CurrWindow.transform.position = new Vector3(DomainStorage.CurrWindow.transform.position.x, DomainStorage.CurrWindow.transform.position.y, 10); //Move curr window back
            window.transform.position = new Vector3(window.transform.position.x, window.transform.position.y, 0);  //Move new window up
            DomainStorage.CurrWindow = window;
        }
    }
}