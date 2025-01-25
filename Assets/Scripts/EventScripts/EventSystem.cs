using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class eventSystem
{
    public static event Action<string> errorMessage;

    public static void fireEvent(eventType type)
    {
        switch (type.getEventType())
        {
            case eventType.EventTypes.ERROR_MESSAGE:
                ErrorEvent errorMes = (ErrorEvent)(type);
                errorMessage.Invoke(errorMes.getMessage());
                Debug.Log(errorMes.getMessage());
                break;
        }
    }
}
