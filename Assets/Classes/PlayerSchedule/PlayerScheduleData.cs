using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerScheduleData
{
    public List<PlayerScheduleEvent> playerScheduleEvents;

    public PlayerScheduleData(PlayerSchedule _playerSchedule)
    {
        playerScheduleEvents = new List<PlayerScheduleEvent>();
        foreach (PlayerScheduleEvent playerScheduleEvent in _playerSchedule.scheduleEvents)
        {
            playerScheduleEvents.Add(playerScheduleEvent);
        }
    }
}
