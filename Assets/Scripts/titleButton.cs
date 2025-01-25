using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleButton : MonoBehaviour
{

    private sceneMan s;
    [SerializeField] Button b;

    void Start()
    {
        s = GameObject.FindWithTag("SceneManager").GetComponent<sceneMan>();
        b.onClick.AddListener(s.startGame);
    }

}
