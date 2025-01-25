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
    private List<int> alreadyUsedTrends = new List<int>();

    void Start()
    {
        allTrends = DomainStorage.createFullTrendList();

        for (int i = 0; i < hotTrends.Length; i++)
        {
            FillTrends(i);
        }
    }

    void Update()
    {
        if ((int)timer.getTimeElapsed() % 2 == 0)
        {
            if(timer.getStartGame())
            {
                for (int i = 0; i < hotTrends.Length; i++)
                {
                    FillTrends(i);
                }
            }
        }
    }

    void FillTrends(int i)
    {
        int randIndex = Random.Range(1, allTrends.Count);
        if (alreadyUsedTrends.Contains(randIndex))
        {
            FillTrends(i);
        }
        else
        {
            hotTrends[i] = allTrends[randIndex];
            hotTrendsText[i].text = hotTrends[i];
            alreadyUsedTrends.Add(randIndex);
        }
    }
}
