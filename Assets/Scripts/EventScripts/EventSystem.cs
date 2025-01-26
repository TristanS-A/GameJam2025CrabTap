using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class eventSystem
{
    public static event Action<string> errorMessage;
    public static event Action<string> removeTab;
    public static event Action<string, string> newTab;
    public static event Action endGame;

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
            case eventType.EventTypes.REMOVE_TAB:
                RemoveTabEvent removeTabEvent = (RemoveTabEvent)(type);
                removeTab.Invoke(removeTabEvent.getURL());
                break;
            case eventType.EventTypes.END_GAME:
                endGame.Invoke();
                break;
        }
    }
}
