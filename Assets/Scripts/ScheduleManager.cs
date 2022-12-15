using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleManager : MonoBehaviour
{
    public GameObject listContent;
    public GameObject eventItemPrefab;
    public GameObject addEventButtonPrefab;

    [InspectorButton("resetCurrentSchedule")]
    public bool resetSchedule;

    void Start() {
        UpdateList();
    }

    void UpdateList() {
        // remove all children
        foreach (Transform child in listContent.transform) {
            GameObject.Destroy(child.gameObject);
        }

        PlayerSchedule playerSchedule = new PlayerSchedule();
        PlayerScheduleData playerScheduleData = SaveSystem.LoadPlayerSchedule();
        if (playerScheduleData != null)
        {
            playerSchedule = new PlayerSchedule(playerScheduleData);
        }

        for (int i = 0; i < playerSchedule.getEventCount(); i++)
        {
            PlayerScheduleEvent playerScheduleEvent = playerSchedule.getEvent(i);
            GameObject eventItem = Instantiate(eventItemPrefab, listContent.transform);
            eventItem.GetComponent<EventItemComponent>().eventName = playerScheduleEvent.eventName;
            eventItem.GetComponent<EventItemComponent>().eventWeekday = WeekdayConverter.ConvertWeekdayIntToString(playerScheduleEvent.eventWeekday);
            eventItem.GetComponent<EventItemComponent>().eventTimeStart = playerScheduleEvent.eventTimeStart;
            eventItem.GetComponent<EventItemComponent>().eventTimeEnd = playerScheduleEvent.eventTimeEnd;
            eventItem.GetComponent<EventItemComponent>().eventType = playerScheduleEvent.eventType;
        }

        GameObject addEventButton = Instantiate(addEventButtonPrefab, listContent.transform);
    }

    public void resetCurrentSchedule() {
        Debug.Log("Resetting schedule...");
        SaveSystem.resetSaveFile(SaveSystem.playerSchedulePath);
        UpdateList();
    }
}
