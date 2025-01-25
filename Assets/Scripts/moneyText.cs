using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class moneyText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI t;
    [SerializeField] private beanKounter playerMoney;
    void Start()
    {
        playerMoney = GameObject.FindWithTag("money").GetComponent<beanKounter>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoney.addMonee(0.05f);
        string s = "$" + (Mathf.Round(playerMoney.getMonee() * 100f) / 100f).ToString();
        if(s.Length - s.IndexOf(".") <= 2)
        {
            s += "0";
        }
        t.text = s;
    }
}
