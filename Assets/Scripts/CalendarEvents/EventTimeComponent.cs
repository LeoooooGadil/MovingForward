using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventTimeComponent : MonoBehaviour
{
	public TMP_Dropdown timeStartDropdown;
	public TMP_Dropdown timeEndDropdown;

	string[] StartTimeSlots;
	string[] EndTimeSlots;

	public string StartTime = "00:00:00";
	public string EndTime = "00:00:00";

	public string _cacheStartTime;
	public string _cacheEndTime;

	// Start is called before the first frame update
	void Start()
	{
		timeStartDropdown = GameObject.Find("TimeStartDropdown").GetComponent<TMP_Dropdown>();
		timeEndDropdown = GameObject.Find("TimeEndDropdown").GetComponent<TMP_Dropdown>();

		generateTimeStartSlots();
		generateTimeEndSlots();
	}

	void generateTimeStartSlots()
	{
		timeStartDropdown.ClearOptions();
		TimeGenerator tg = new TimeGenerator();
		tg.setTime("00:00 AM");
		StartTimeSlots = new string[49];
		timeStartDropdown.options.Add(new TMP_Dropdown.OptionData("Start"));

		for (int i = 0; i < StartTimeSlots.Length; i++)
		{
			string time = presentTime(tg.getHours()) + ":" + presentTime(tg.getMinutes()) + " " + tg.getAMPM();
			int curMilliseconds = tg.timeToMilliseconds(time);
			StartTimeSlots[i] = time;
			timeStartDropdown.options.Add(new TMP_Dropdown.OptionData(time));
			tg.addTime(0, 30, 0);
		}
	}

	void generateTimeEndSlots()
	{
		timeEndDropdown.ClearOptions();
		TimeGenerator tg = new TimeGenerator();
		if(StartTime == "Start")
			tg.setTime("00:00 AM");
		else
			tg.setTime(StartTime);
        tg.addTime(0, 30, 0);
		int count = tg.getIntervalCount("23:59 PM", 1800) + 1;
		EndTimeSlots = new string[count];
		timeEndDropdown.options.Add(new TMP_Dropdown.OptionData("End"));

		for (int i = 0; i < EndTimeSlots.Length; i++)
		{
			string time = presentTime(tg.getHours()) + ":" + presentTime(tg.getMinutes()) + " " + tg.getAMPM();
			int curMilliseconds = tg.timeToMilliseconds(time);
			EndTimeSlots[i] = time;
			timeEndDropdown.options.Add(new TMP_Dropdown.OptionData(time));
			tg.addTime(0, 30, 0);
		}
	}

	string presentTime(int time)
	{
		if (time < 10)
			return "0" + time;

		return time.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		StartTime = timeStartDropdown.captionText.text;
		EndTime = timeEndDropdown.captionText.text;

		if (_cacheStartTime != StartTime)
		{
			_cacheStartTime = StartTime;
			_cacheEndTime = EndTime;
			generateTimeEndSlots();
            timeEndDropdown.RefreshShownValue();
		}
	}
}
