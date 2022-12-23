using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventItemComponent : MonoBehaviour
{
    public GameObject eventTitleObject;
    public GameObject eventWeekdayObject;
    public GameObject eventTimeObject;
    public GameObject eventTypeObject;


    public string eventName;
    public string eventWeekday;
    public string eventTimeStart;
    public string eventTimeEnd;
    public string eventType;

    Button thisButton;
    public bool isPushed;

    void Start()
    {
        thisButton = GetComponent<Button>();

        eventTitleObject.GetComponent<TMPro.TextMeshProUGUI>().text = eventName;
        eventWeekdayObject.GetComponent<TMPro.TextMeshProUGUI>().text = eventWeekday;
        eventTimeObject.GetComponent<TMPro.TextMeshProUGUI>().text = eventTimeStart + " - " + eventTimeEnd;
        eventTypeObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Type: " + eventType;
    }
}
