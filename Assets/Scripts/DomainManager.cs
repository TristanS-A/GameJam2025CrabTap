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

    private void Start()
    {
        mInputField.ActivateInputField();
        mConfirmButton.onClick.AddListener(checkAndConfirmDomainID);
        DomainStorage.BuildUrlPacks();
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
            ///ADD PROFITS AND CALCULATE BASED ON TRENDS
            ///ADD NEW TAB
        }
        else
        {
            Debug.Log("Domain does not exist");
        }
    }
}
