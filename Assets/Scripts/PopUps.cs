using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform borderRect;
    public Sprite[] popUpImages;
    public Canvas mainCanvas;
    public Button xButton;
    public timerScript timerScript;

    private int currentRandImageIndex;
    private Vector2 imagePosition;
    private Sprite currentImage;
    private int missedPopUpCounter = 0;

    void Start()
    {
        currentRandImageIndex = Random.Range(0, popUpImages.Length);
        currentImage = popUpImages[currentRandImageIndex];
        gameObject.GetComponent<Image>().sprite = currentImage;
        xButton.onClick.AddListener(xButtonClick);
        rectTransform = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        if ((int)timerScript.getTimeElapsed() % 10 == 0)
        {
            if (timerScript.getStartGame())
            {
                int popUpChance = Random.Range(0, 1);
                if (popUpChance == 1)
                {
                    CreatePopUp();
                }
                if (missedPopUpCounter == 3)
                {
                    CreatePopUp();
                    missedPopUpCounter = 0;
                    Debug.Log("Pop up");
                }
                else
                {
                    missedPopUpCounter++;
                    Debug.Log("missed chance");
                }
            }
        }
    }

    void xButtonClick()
    {
        gameObject.transform.position = new Vector2(10000, 10000);
    }

    void CreatePopUp()
    {
        currentRandImageIndex = Random.Range(0, popUpImages.Length);
        currentImage = popUpImages[currentRandImageIndex];
        gameObject.GetComponent<Image>().sprite = currentImage;
        imagePosition.x = Random.Range(-400, 300);
        imagePosition.y = Random.Range(-150, 210);
        rectTransform.anchoredPosition = imagePosition;
        borderRect.anchoredPosition = imagePosition;
    }
}
