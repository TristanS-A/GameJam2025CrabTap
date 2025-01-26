using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTabEvent : eventType
{
    private string url;

    public NewTabEvent(string url) : base(eventType.EventTypes.NEW_TAB)
    {
        this.url = url;
    }

    public string getURL()
    {
        return url;
    }
}
