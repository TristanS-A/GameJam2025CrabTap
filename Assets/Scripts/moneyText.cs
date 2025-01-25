using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class moneyText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI t;
    [SerializeField] private beanKounter playerMoney;

    // Update is called once per frame
    void Update()
    {
        t.text = (Mathf.Round(playerMoney.getMonee()* 100f) / 100f).ToString();
    }
}
