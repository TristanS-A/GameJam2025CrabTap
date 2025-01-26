using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTabEvent : eventType
{
    private string url;

    public RemoveTabEvent(string url) : base(eventType.EventTypes.REMOVE_TAB)
    {
        this.url = url;
    }

    public string getURL()
    {
        return url;
    }
}
