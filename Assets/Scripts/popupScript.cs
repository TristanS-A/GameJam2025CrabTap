using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popupScript : MonoBehaviour
{
    public Button xButton;
    private float timeLeft = 1f;
    private int currentRandImageIndex = 0;
    private Vector2 imagePosition;
    private Sprite currentImage;
    public RectTransform rectTransform;
    public RectTransform borderRect;
    public Sprite[] popUpImages;

    // Start is called before the first frame update
    void Start()
    {
        xButton.onClick.AddListener(xButtonClick);
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            ChangePos();
            timeLeft -= Time.deltaTime;
        }
    }

    void ChangePos()
    {
        currentRandImageIndex = Random.Range(0, popUpImages.Length);
        currentImage = popUpImages[currentRandImageIndex];
        gameObject.GetComponent<Image>().sprite = currentImage;
        imagePosition.x = Random.Range(-400, 300);
        imagePosition.y = Random.Range(-150, 210);
        rectTransform.anchoredPosition = imagePosition;
        borderRect.anchoredPosition = imagePosition;
    }

    void xButtonClick()
    {
        Destroy(gameObject.GetComponentInParent<Canvas>().gameObject);
    }
}
