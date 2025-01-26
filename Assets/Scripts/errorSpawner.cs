using UnityEngine;

public class errorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_ErrorPopup;
    [SerializeField] private GameObject m_EndOfGamePopup;

    private void OnEnable()
    {
        eventSystem.errorMessage += spawnError;
        eventSystem.endGame += spawnEndOfGamePopup;
    }

    private void OnDisable()
    {
        eventSystem.errorMessage -= spawnError;
        eventSystem.endGame -= spawnEndOfGamePopup;
    }

    private void spawnError(string message)
    {
        GameObject errorPopup = Instantiate(m_ErrorPopup, transform);
        errorPopup.GetComponent<errorScript>().setErrorMessage(message);
    }

    private void spawnEndOfGamePopup()
    {
        Instantiate(m_EndOfGamePopup);
    }
}
