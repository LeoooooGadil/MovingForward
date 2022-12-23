using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventCreator : MonoBehaviour
{

	public GameObject eventTitleInputField;
	public GameObject eventTypeDropdown;

	public GameObject eventWeekInputField;
	public GameObject eventTimeStartDropdown;
	public GameObject eventTimeEndDropdown;
	public GameObject eventFormControlsOkButton;
	public GameObject eventFormControlsCancelButton;
	Button okButton;
	Button cancelButton;

	public string eventTitle;
	public string eventType;
	public string eventWeek;
	public string eventTimeStart;
	public string eventTimeEnd;

	public bool isAllFieldsFilled;

	public EventCreator event_creator;
	public static EventCreator instance;

	void Awake()
	{
		if (instance == null) { instance = this; }
		else { Destroy(gameObject); }

		event_creator = FindObjectOfType<EventCreator>();
	}

	public void SaveEvent()
	{
		PlayerSchedule playerSchedule = new PlayerSchedule();
		PlayerScheduleData playerScheduleData = SaveSystem.LoadPlayerSchedule();
		if (playerScheduleData != null)
		{
			playerSchedule = new PlayerSchedule(playerScheduleData);
		}
		playerSchedule.addEvent(new PlayerScheduleEvent(
			eventTitle,
			eventTimeStart,
			eventTimeEnd,
			eventWeek,
			eventType
		));
		SaveSystem.SavePlayerSchedule(playerSchedule);
	}

	// Update is called once per frame
	void Update()
	{
		string _title = eventTitleInputField.GetComponent<TMP_InputField>().text;
		string _type = eventTypeDropdown.GetComponent<TMP_Dropdown>().captionText.text;
		bool[] _week = eventWeekInputField.GetComponent<WeekdayComponent>().activatedWeekdays;
		string _timeStart = eventTimeStartDropdown.GetComponent<TMP_Dropdown>().captionText.text;
		string _timeEnd = eventTimeEndDropdown.GetComponent<TMP_Dropdown>().captionText.text;
		okButton = eventFormControlsOkButton.GetComponent<Button>();
		cancelButton = eventFormControlsCancelButton.GetComponent<Button>();

		okButton.interactable = false;

		// if you put a new data please put it here or it will not update.
		if (eventTitle == _title &&
			eventType == _type &&
			eventWeek == _week.ToString() &&
			eventTimeStart == _timeStart &&
			eventTimeEnd == _timeEnd
		)
		{
			return;
		}

		// put 1 if the weekday is activated, 0 if not
		string _weekString = "";
		for (int i = 0; i < _week.Length; i++)
		{
			if (_week[i])
			{
				_weekString += "1";
			}
			else
			{
				_weekString += "0";
			}
		}

		eventTitle = _title;
		eventType = _type;
		eventTimeStart = _timeStart;
		eventTimeEnd = _timeEnd;
		eventWeek = _weekString;


		// check if all fields are filled

		// check if title is filled
		if (eventTitle == "")
		{
			isAllFieldsFilled = false;
			return;
		}

		// check if type is filled
		if (eventType == "Type")
		{
			isAllFieldsFilled = false;
			return;
		}

		// check if week is filled
		if (eventWeek == "0000000")
		{
			isAllFieldsFilled = false;
			return;
		}

		// check if time start is filled
		if (eventTimeStart == "Start")
		{
			isAllFieldsFilled = false;
			return;
		}

		// check if time end is filled
		if (eventTimeEnd == "End")
		{
			isAllFieldsFilled = false;
			return;
		}

		okButton.interactable = true;

		isAllFieldsFilled = true;
	}
}
