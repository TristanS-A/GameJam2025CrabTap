using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class eventSystem
{
    public static event Action<string> errorMessage;
    public static event Action<string, string> newTab;

    public static void fireEvent(eventType type)
    {
        switch (type.getEventType())
        {
            case eventType.EventTypes.ERROR_MESSAGE:
                ErrorEvent errorMes = (ErrorEvent)(type);
                errorMessage.Invoke(errorMes.getMessage());
                break;
            case eventType.EventTypes.NEW_TAB:
                NewTabEvent tabEvent = (NewTabEvent)(type);
                newTab.Invoke(tabEvent.getURL(), tabEvent.getURL());
                break;
        }
    }
}
