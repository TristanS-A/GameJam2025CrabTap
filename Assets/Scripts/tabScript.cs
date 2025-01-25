using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabScript : MonoBehaviour
{
    private string windowID;

    public string WindowName {
        get { return windowID; }
        set { windowID = value; }
    }
}
