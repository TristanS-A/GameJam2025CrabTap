using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class eventSystem
{
    public static event Action<string> makeTextPopUp;

    public static void fireEvent(eventType type)
    {
        switch (type.getEventType())
        {
            case eventType.EventTypes.Confirm:
                //startGame.Invoke();
                break;
        }
    }
}
