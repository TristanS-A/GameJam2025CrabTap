using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupButton : MonoBehaviour
{
    public void clickTuah()
    {
        gameObject.SetActive(false);
    }

    public void resetButton()
    {
        gameObject.SetActive(true);
    }
}
