using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timerScript : MonoBehaviour
{
    private float timeElapsed;
    [SerializeField] private float finalTime;
    [SerializeField] private TextMeshProUGUI t;
    private bool startGame = false;

    void Start()
    {
        timeElapsed = finalTime;
    }

    void Update()
    {
        if(startGame)
        {
            //Add to timer and finish game if timer passes target time (6 mins)
            if (timeElapsed <= 0)
            {
                startGame = false;
                Debug.Log("DONE");
            }
            else
            {
                timeElapsed -= Time.deltaTime;
                //Update timer
                t.text = convertTimer();
            }
        }
    }

    //Function to start timer
    public void playGame()
    {
        timeElapsed = finalTime;
        startGame = true;
    }

    private string convertTimer()
    {
        int hoursLeft = (int)(timeElapsed * 2) / 60;
        int secondsLeft = (int)((timeElapsed * 2) % 60);
        if(secondsLeft < 10)
        {
            return (hoursLeft + ":0" + secondsLeft);
        }
        else
        {
            return (hoursLeft + ":" + secondsLeft);
        }
    }
}
