using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventTypeComponent : MonoBehaviour
{
    public EventTypes eventTypes;
    public TMP_Dropdown dropdown;

    void Start()
    {
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach (EventType eventType in eventTypes.eventTypes)
        {
            options.Add(eventType.name);
        }
        dropdown.AddOptions(options);
    }

    void Update()
    {

    }
}
