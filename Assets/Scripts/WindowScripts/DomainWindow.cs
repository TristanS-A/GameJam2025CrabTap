using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DomainWindow : MonoBehaviour
{
    [SerializeField] private GameObject mDomainGroup;
    [SerializeField] private GameObject mDomainIDGroup;
    [SerializeField] public TMP_FontAsset font;
    [SerializeField] private Sprite[] siteBGs;

    // Start is called before the first frame update
    void Start()
    {
        DomainStorage.BuildUrlPacks();
        DomainStorage.createFullTrendList();
        loadBGs();
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
        GameObject newDomainPriceOBJ = new GameObject("DomainPrice");

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
        domainRect.position = new Vector2(8, 0);
        newDomainIDOBJ.transform.SetParent(newDomainOBJ.transform);

        domainTextComp = newDomainPriceOBJ.AddComponent<TextMeshProUGUI>();
        domainRect = newDomainPriceOBJ.GetComponent<RectTransform>();
        domainTextComp.text = "$" + domainInfo.price.ToString("0.00");
        domainTextComp.color = Color.black;
        domainTextComp.fontSize = 0.5f;
        domainTextComp.font = font;
        domainRect.sizeDelta = new Vector2(8, 1);
        domainRect.position = new Vector2(13, 0);
        newDomainPriceOBJ.transform.SetParent(newDomainOBJ.transform);

        newDomainOBJ.transform.SetParent(mDomainGroup.transform);
    }

    private void loadBGs()
    {
        var domains = DomainStorage.getDomainInfoList();
        for (int i = 0; i < domains.Count; i++)
        {
            DomainStorage.DomainInfo info = DomainStorage.getDomainInfoFromID(domains.ElementAt(i).Key).Value;

            if (info.trends[0] == DomainStorage.getAllTRends()[1]) //Toys
            {
                info.bg = siteBGs[0];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[2]) //MTV
            {
                info.bg = siteBGs[1];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[3]) //Pop Culture
            {
                info.bg = siteBGs[2];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[4]) //Fashion
            {
                info.bg = siteBGs[3];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[5]) //Video Games
            {
                info.bg = siteBGs[4];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[6]) //Business
            {
                info.bg = siteBGs[5];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[7]) //Scams
            {
                info.bg = siteBGs[6];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[8]) //Jokes
            {
                info.bg = siteBGs[7];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[9]) //Education
            {
                info.bg = siteBGs[8];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
            else if (info.trends[0] == DomainStorage.getAllTRends()[10]) //Conspiracy
            {
                info.bg = siteBGs[9];
                DomainStorage.setDomainInfoFromID(domains.ElementAt(i).Key, info);
            }
        }
    }
}
