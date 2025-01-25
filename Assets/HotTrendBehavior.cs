using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HotTrendBehavior : MonoBehaviour
{
    public TextMeshProUGUI[] hotTrendsText = new TextMeshProUGUI[3];
    public timerScript timer;

    private string[] hotTrends = new string[3];
    private List<string> allTrends;
    private List<string> alreadyUsedTrends = new List<string>();

    void Start()
    {
        allTrends = DomainStorage.createFullTrendList();
        FillTrends();
    }

    void Update()
    {
        if ((int)timer.getTimeElapsed() % 2 == 0)
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
            alreadyUsedTrends.Add(allTrends[randIndex]);
        }
    }
}
