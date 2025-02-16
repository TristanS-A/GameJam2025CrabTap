using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trendManager : MonoBehaviour
{
    private List<string> trends;

    // Start is called before the first frame update
    void Start()
    {
        trends = DomainStorage.createFullTrendList();
    }


    //Moves a trend to index loc
    private void moveTrend(string trend, int loc)
    {
        string s = trends[loc];
        int i = trends.IndexOf(trend);
        trends[loc] = trend;
        trends[i] = s;
    }

    public List<string> getTrends()
    {
        return trends;
    }

    public float getTrendMult(string trend)
    {
        int i = trends.IndexOf(trend);
        return 2.0f - (0.1f * i);
    }

    public void updateTrends()
    {
        //Make sure the None trend is at the bottom
        moveTrend("None", trends.Count);
        //New list to track old positions of trends
        List<string> s = trends;
        s.RemoveAt(10);
        //Randomly order top 10 trends
        for (int i = 0; i < 9; i++)
        {
            //Get a new random position that hasn't been taken up yet
            int j = Random.Range(0, 10);
            while (!s.Contains(trends[j]))
            {
                j = Random.Range(0, 10);
            }
            //Move the trend to its new position and remove it within the temp list
            moveTrend(trends[i], j);
            s.Remove(trends[j]);
        }
    }
}
