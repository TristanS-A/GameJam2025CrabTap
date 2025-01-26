using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class errorScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_ErrorText;
    [SerializeField] private Button destroyButton;

    private void Start()
    {
        soundManager.Instance.playSFX(1);
        destroyButton.onClick.AddListener(deletePopup);
    }

    public void setErrorMessage(string message)
    {
        m_ErrorText.text = message;
    }

    private void deletePopup()
    {
        Destroy(gameObject);
    }
}
