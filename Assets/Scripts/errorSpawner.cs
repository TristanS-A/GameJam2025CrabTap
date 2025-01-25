using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class errorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_ErrorPopup;

    private void OnEnable()
    {
        eventSystem.errorMessage += spawnError;
    }

    private void OnDisable()
    {
        eventSystem.errorMessage -= spawnError;
    }

    private void spawnError(string message)
    {
        GameObject errorPopup = Instantiate(m_ErrorPopup, transform);
        errorPopup.GetComponent<errorScript>().setErrorMessage(message);
    }
}
