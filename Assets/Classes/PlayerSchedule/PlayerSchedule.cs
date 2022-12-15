public class PlayerSchedule
{
    public PlayerScheduleEvent[] scheduleEvents;

    public PlayerSchedule(PlayerScheduleData playerScheduleData)
    {
        scheduleEvents = new PlayerScheduleEvent[playerScheduleData.playerScheduleEvents.Count];
        for (int i = 0; i < playerScheduleData.playerScheduleEvents.Count; i++)
        {
            scheduleEvents[i] = playerScheduleData.playerScheduleEvents[i];
        }
    }

    public PlayerSchedule()
    {
        scheduleEvents = new PlayerScheduleEvent[0];
    }

    public void addEvent(PlayerScheduleEvent playerScheduleEvent)
    {
        PlayerScheduleEvent[] newScheduleEvents = new PlayerScheduleEvent[scheduleEvents.Length + 1];
        for (int i = 0; i < scheduleEvents.Length; i++)
        {
            newScheduleEvents[i] = scheduleEvents[i];
        }
        newScheduleEvents[scheduleEvents.Length] = playerScheduleEvent;
        scheduleEvents = newScheduleEvents;
    }

    public void removeEvent(int index)
    {
        PlayerScheduleEvent[] newScheduleEvents = new PlayerScheduleEvent[scheduleEvents.Length - 1];
        for (int i = 0; i < index; i++)
        {
            newScheduleEvents[i] = scheduleEvents[i];
        }
        for (int i = index + 1; i < scheduleEvents.Length; i++)
        {
            newScheduleEvents[i - 1] = scheduleEvents[i];
        }
        scheduleEvents = newScheduleEvents;
    }

    public void editEvent(int index, PlayerScheduleEvent playerScheduleEvent)
    {
        scheduleEvents[index] = playerScheduleEvent;
    }

    public PlayerScheduleEvent getEvent(int index)
    {
        return scheduleEvents[index];
    }

    public int getEventCount()
    {
        return scheduleEvents.Length;
    }

    public PlayerScheduleEvent[] getEvents()
    {
        return scheduleEvents;
    }

    
}
