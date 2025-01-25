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
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentRandImageIndex = Random.Range(0, popUpImages.Length);
            currentImage = popUpImages[currentRandImageIndex];
            imagePosition.x = Random.Range(-500, 400);
            imagePosition.y = Random.Range(-150, 210);
            rectTransform.anchoredPosition = imagePosition;
        }
    }

    void xButtonClick()
    {
        this.gameObject.transform.position = new Vector2(10000, 10000);
    }
}
