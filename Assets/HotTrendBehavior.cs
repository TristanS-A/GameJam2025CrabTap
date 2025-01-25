using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HotTrendBehavior : MonoBehaviour
{
    public TextMeshProUGUI[] hotTrendsText = new TextMeshProUGUI[3];
    public timerScript timer;

    private string[] hotTrends = new string[3];
    private List<string> allTrends;
    private int[] alreadyUsedTrends;

    void Start()
    {
        allTrends = DomainStorage.createFullTrendList();

        FillTrends();
        alreadyUsedTrends = new int[allTrends.Count];

    }

    void Update()
    {
        if ((int)timer.getTimeElapsed() % 60 == 0)
        {
            if(timer.getStartGame())
            {
                FillTrends();
            }
        }
    }

    void FillTrends()
    {
        for (int i = 0; i < hotTrends.Length; i++)
        {
            int randIndex = Random.Range(1, allTrends.Count);
            hotTrends[i] = allTrends[randIndex];
            hotTrendsText[i].text = hotTrends[i];
        }
    }
}
