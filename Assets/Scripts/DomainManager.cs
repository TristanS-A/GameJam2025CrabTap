using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DomainManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField mInputField;
    private event Action <string> AmOnInputEdit;

    private void Start()
    {
        mInputField.ActivateInputField();
        //mInputField.onEndEdit.AddListener(test);
    }

//    private void test(string s)
//    {
//        Debug.Log(s);
//    }
}
