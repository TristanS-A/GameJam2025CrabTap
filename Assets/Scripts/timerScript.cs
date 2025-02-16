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
        //playGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!startGame)
            {
                playGame();
            }
        }

        if(startGame)
        {
            //Add to timer and finish game if timer passes target time (6 mins)
            if (timeElapsed <= 0)
            {
                startGame = false;
                eventSystem.fireEvent(new eventType(eventType.EventTypes.END_GAME));
            }
            else
            {
                timeElapsed -= Time.deltaTime;
                //Update timer
                t.text = convertTimer();
            }
        }
    }

    //Function to start timer and song
    public void playGame()
    {
        timeElapsed = finalTime;
        startGame = true;
        soundManager.Instance.startSong();
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

    public float getTimeElapsed()
    {
        return timeElapsed;
    }

    public bool getStartGame()
    {
        return startGame;
    }
}
