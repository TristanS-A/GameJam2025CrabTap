using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tabButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject tabPrefab;
    public List<Button> purchasedDomains;
    [SerializeField] Button websiteTabTemplate;
    [SerializeField] Canvas canvas;
    private RectTransform tabBarRect; 

    private List<GameObject> tabButtons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        tabBarRect = GetComponent<RectTransform>();
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("Hello");
        addTab("End");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toWebsite()
    {

    }

    //Function to add a new button
    public void addTab(string title)
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
    }
}
