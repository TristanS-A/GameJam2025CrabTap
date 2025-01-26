using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DomainWindow : MonoBehaviour
{
    [SerializeField] private GameObject mDomainGroup;
    [SerializeField] private GameObject mDomainIDGroup;
    [SerializeField] public TMP_FontAsset font;

    // Start is called before the first frame update
    void Start()
    {
        DomainStorage.BuildUrlPacks();
        foreach (string domainID in DomainStorage.getDomainInfoList().Keys)
        {
            DomainStorage.DomainInfo domainInfo = (DomainStorage.DomainInfo)DomainStorage.getDomainInfoFromID(domainID);
            createDomainText(domainInfo, domainID);
        }

        RectTransform domainGroupTansform = mDomainGroup.GetComponent<RectTransform>();
        RectTransform domainIDGroupTansform = mDomainIDGroup.GetComponent<RectTransform>();
        domainGroupTansform.position = new Vector3(domainGroupTansform.position.x, -200, domainGroupTansform.position.z);
        domainIDGroupTansform.position = new Vector3(domainIDGroupTansform.position.x, -200, domainIDGroupTansform.position.z);
    }

    private void createDomainText(DomainStorage.DomainInfo domainInfo, string domainID)
    {
        GameObject newDomainOBJ = new GameObject("Domain");
        GameObject newDomainURLOBJ = new GameObject("DomainURL");
        GameObject newDomainIDOBJ = new GameObject("DomainID");

        RectTransform domainRect = newDomainOBJ.AddComponent<RectTransform>();
        domainRect.sizeDelta = new Vector2(5, 1);


        TextMeshProUGUI domainTextComp = newDomainURLOBJ.AddComponent<TextMeshProUGUI>();
        domainRect = newDomainURLOBJ.GetComponent<RectTransform>();
        domainTextComp.text = domainInfo.url;
        domainTextComp.color = Color.black;
        domainTextComp.fontSize = 0.5f;
        domainTextComp.font = font;
        domainRect.sizeDelta = new Vector2(8, 1);
        newDomainURLOBJ.transform.SetParent(newDomainOBJ.transform);

        domainTextComp = newDomainIDOBJ.AddComponent<TextMeshProUGUI>();
        domainRect = newDomainIDOBJ.GetComponent<RectTransform>();
        domainTextComp.text = domainID;
        domainTextComp.color = Color.black;
        domainTextComp.fontSize = 0.5f;
        domainTextComp.font = font;
        domainRect.sizeDelta = new Vector2(8, 1);
        domainRect.position = new Vector2(9, 0);
        newDomainIDOBJ.transform.SetParent(newDomainOBJ.transform);

        newDomainOBJ.transform.SetParent(mDomainGroup.transform);
    }
}
