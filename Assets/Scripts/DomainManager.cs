using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DomainManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField mInputField;
    [SerializeField] private Button mConfirmButton;
    private HashSet<string> mAqquiredDomains;        ///CHANGE THIS TO REMOVE ADDED DOMAINS
    private beanKounter money;
    private trendManager trend;

    private void Start()
    {
        mInputField.ActivateInputField();
        mConfirmButton.onClick.AddListener(checkAndConfirmDomainID);
        DomainStorage.BuildUrlPacks();
        money = GameObject.FindWithTag("money").GetComponent<beanKounter>();
        trend = GameObject.FindWithTag("trends").GetComponent<trendManager>();
    }

    private void checkAndConfirmDomainID()
    {
        Nullable<DomainStorage.DomainInfo> possibleDomainInfo = DomainStorage.getDomainInfoFromID(mInputField.text);
        if (possibleDomainInfo != null)
        {
            Debug.Log("Exists");
            Debug.Log(possibleDomainInfo.Value.url);
            Debug.Log(possibleDomainInfo.Value.trends);
            ////REMOVE DOMAIN FROM DomainStorage
            DomainStorage.removeID(mInputField.text);
            ///ADD PROFITS AND CALCULATE BASED ON TRENDS
            money.subtractMonee(0.05f);
            float f = 0.20f;
            for(int i = 0; i < possibleDomainInfo.Value.trends.Length; i++)
            {
                f *= trend.getTrendMult(possibleDomainInfo.Value.trends[i]);
            }
            money.addMonee(f);
            ///ADD NEW TAB
        }
        else
        {
            Debug.Log("Domain does not exist");
        }
    }
}
