using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class sceneMan : MonoBehaviour
{
    [SerializeField] private VideoPlayer vp;
    bool startup = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        startup = false;
        vp.loopPointReached += mainMenu;
    }

    void Update()
    {
        if(!startup)
        {
            //If video player is done playing
            if(vp.frame !< Convert.ToInt64(vp.GetComponent<VideoPlayer>().frameCount))
            {
                startup = true;
            }
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game 2");
        soundManager.Instance.startSong();
    }

    public void mainMenu(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Title");
    }
}
