using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEditor.PackageManager.UI;

public class DomainManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField mInputField;
    [SerializeField] private Button mConfirmButton;
    private List<Website> mAqquiredDomains;        ///CHANGE THIS TO REMOVE ADDED DOMAINS
    private beanKounter money;
    private trendManager trend;

    private void OnEnable()
    {
        eventSystem.endGame += dissableInput;
    }

    private void OnDisable()
    {
        eventSystem.endGame -= dissableInput;
    }

    private void dissableInput()
    {
        mInputField.enabled = false;
    }

    private void Start()
    {
        mInputField.ActivateInputField();
        mConfirmButton.onClick.AddListener(checkAndConfirmDomainID);
        money = GameObject.FindWithTag("money").GetComponent<beanKounter>();
        trend = GameObject.FindWithTag("trends").GetComponent<trendManager>();
    }

    private void checkAndConfirmDomainID()
    {
        Nullable<DomainStorage.DomainInfo> possibleDomainInfo = DomainStorage.getDomainInfoFromID(mInputField.text);
        if (possibleDomainInfo != null)
        {
            if (playerMoneyHandler.PlayerMoney < possibleDomainInfo.Value.price)
            {
                eventSystem.fireEvent(new ErrorEvent("Not enough money!"));
                return;
            }

            Debug.Log("Exists");
            Debug.Log(possibleDomainInfo.Value.url);
            Debug.Log(possibleDomainInfo.Value.trends);
            ////REMOVE DOMAIN FROM DomainStorage
            DomainStorage.removeID(mInputField.text);
            DomainStorage.addToBoughtURLs(mInputField.text, (DomainStorage.DomainInfo)possibleDomainInfo);
            ///ADD PROFITS AND CALCULATE BASED ON TRENDS    AND URL COST
            playerMoneyHandler.PlayerMoney -= possibleDomainInfo.Value.price; //SHOULD SUBTRACT BY URL COST
            eventSystem.fireEvent(new NewTabEvent(possibleDomainInfo.Value.url));
            Website newWebsite = DomainStorage.getWindowFromKey(possibleDomainInfo.Value.url).GetComponent<Website>();
            newWebsite.urlID = mInputField.text;
        }
        else
        {
            eventSystem.fireEvent(new ErrorEvent("Domain does not exist!"));
            Debug.Log("Domain does not exist");
        }
    }
}
