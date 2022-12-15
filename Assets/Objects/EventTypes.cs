using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event Type", menuName = "Moving Forward/Calendar/New Event Types", order = 1)]
public class EventTypes : ScriptableObject
{
    [SerializeField]
    List<EventType> _eventTypes;

    public List<EventType> eventTypes
    {
        get
        {
            return _eventTypes;
        }
    }
}
