using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneMan : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Title");
    }
}
