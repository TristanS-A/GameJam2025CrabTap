using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorEvent : eventType
{
    private string mMessage;

    public ErrorEvent(string message) : base(eventType.EventTypes.ERROR_MESSAGE)
    { 
        mMessage = message;
    }

    public string getMessage()
    {
        return mMessage;
    }
}