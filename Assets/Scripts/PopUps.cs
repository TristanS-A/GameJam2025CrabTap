using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    public GameObject popupPrefab;
    public RectTransform rectTransform;
    public RectTransform borderRect;
    public Sprite[] popUpImages;
    public Canvas mainCanvas;
    public timerScript timerScript;
    private float gracePeriod = 20f;

    private bool createdLastFrame = false;

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (gracePeriod > 0)
        {
            gracePeriod -= Time.deltaTime;
        }
        else
        {
            if ((int)timerScript.getTimeElapsed() % 10 == 0)
            {
                if (timerScript.getStartGame() && !createdLastFrame)
                {
                    CreatePopUp();
                    createdLastFrame = true;
                }
            }
            else
            {
                createdLastFrame = false;
            }
        }
    }

    void CreatePopUp()
    {
        Instantiate(popupPrefab);
    }
}
