using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventType
{
    public enum EventTypes
    {
        ERROR_MESSAGE,
        NEW_TAB,
        END_GAME
    }

    private EventTypes _type;

    public eventType(EventTypes type)
    {
        _type = type;
    }

    public EventTypes getEventType()
    {
        return _type;
    }

    public static explicit operator eventType(EventTypes v)
    {
        throw new NotImplementedException();
    }
}
