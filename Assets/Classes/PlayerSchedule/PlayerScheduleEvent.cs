[System.Serializable]
public class PlayerScheduleEvent
{
    public string eventName;
    public string eventTimeStart;
    public string eventTimeEnd;
    public string eventWeekday;
    public string eventType;

    public PlayerScheduleEvent(string _eventName, string _eventTimeStart, string _eventTimeEnd, string _eventWeekday, string _eventType)
    {
        eventName = _eventName;
        eventTimeStart = _eventTimeStart;
        eventTimeEnd = _eventTimeEnd;
        eventWeekday = _eventWeekday;
        eventType = _eventType;
    }
}
