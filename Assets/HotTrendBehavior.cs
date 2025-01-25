using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HotTrendBehavior : MonoBehaviour
{
    public DomainManager DomainManager;
    public TextMeshProUGUI[] hotTrendsText = new TextMeshProUGUI[3];

    private string[] hotTrends = new string[3];
    private List<string> allTrends;

    void Start()
    {
        allTrends = DomainStorage.createFullTrendList();

        for (int i = 0; i < hotTrends.Length; i++)
        {
            int randIndex = Random.Range(1, allTrends.Count);
            hotTrends[i] = allTrends[randIndex];
            hotTrendsText[i].text = hotTrends[i];
        }
    }

    void Update()
    {
        
    }
}
