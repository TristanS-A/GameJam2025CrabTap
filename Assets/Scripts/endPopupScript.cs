using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endPopupScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mMoneyText;
    [SerializeField] private TextMeshProUGUI mSitesText;

    void Start()
    {
        setText();

        Button currButton = GetComponent<Button>();
        currButton.onClick.AddListener(switchScene);

        Button[] allButtons = FindObjectsOfType<Button>();
        ScrollRect[] scrollRects = FindObjectsOfType<ScrollRect>();

        foreach (ScrollRect rect in scrollRects)
        {
            rect.enabled = false;
        }

        foreach (Button button in allButtons)
        {
            button.enabled = false;
        }

        currButton.enabled = true;
    }

    private void setText()
    {
        mMoneyText.text = "You made $" + (playerMoneyHandler.PlayerMoney - playerMoneyHandler.mStartingMoney).ToString("0.00");
        mSitesText.text = "Domains Bought: " + DomainStorage.getBoughtDomainDictionary().Count;
    }

    private void switchScene()
    {
        SceneManager.LoadScene("Title");
    }
}
