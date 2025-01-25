using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    public RectTransform rectTransform;
    public Texture2D[] popUpImages;
    public Canvas mainCanvas;
    public Button xButton;
    public timerScript timerScript;

    private int currentRandImageIndex;
    private Vector2 imagePosition;
    private Texture currentImage;

    void Start()
    {
        currentRandImageIndex = Random.Range(0, popUpImages.Length);
        currentImage = popUpImages[currentRandImageIndex];
        xButton.onClick.AddListener(xButtonClick);
        rectTransform = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (timerScript.getTimeElapsed() % 10 == 0)
        {
            int popUpChance = Random.Range(0, 1);
            if (popUpChance == 1)
            {
                CreatePopUp();
            }
        }
    }

    void xButtonClick()
    {
        this.gameObject.transform.position = new Vector2(10000, 10000);
    }

    void CreatePopUp()
    {
        currentRandImageIndex = Random.Range(0, popUpImages.Length);
        currentImage = popUpImages[currentRandImageIndex];
        imagePosition.x = Random.Range(-500, 400);
        imagePosition.y = Random.Range(-150, 210);
        rectTransform.anchoredPosition = imagePosition;
    }
}
