using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeekdayConverter
{
    static string[] weekdays = new string[] {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};

    public static string ConvertWeekdayIntToString(bool[] weekdayInt)
	{
		string _weekdayText = "";
        bool[] activatedWeekdays = weekdayInt;

		// check if theres any weekday selected
		if (activatedWeekdays[0] || activatedWeekdays[1] || activatedWeekdays[2] || activatedWeekdays[3] || activatedWeekdays[4] || activatedWeekdays[5] || activatedWeekdays[6])
		{
			_weekdayText = "Every ";
		}

		// add text for each selected weekday seperated by comma
		for (int i = 0; i < activatedWeekdays.Length; i++)
		{
			if (activatedWeekdays[i])
			{
				_weekdayText += weekdays[i] + ", ";
			}
		}

		if (activatedWeekdays[0] && activatedWeekdays[1] && activatedWeekdays[2] && activatedWeekdays[3] && activatedWeekdays[4] && activatedWeekdays[5] && activatedWeekdays[6])
			return "Everyday";

		if (!activatedWeekdays[0] && activatedWeekdays[1] && activatedWeekdays[2] && activatedWeekdays[3] && activatedWeekdays[4] && activatedWeekdays[5] && !activatedWeekdays[6])
			return "Every Weekdays";

		if (activatedWeekdays[0] && !activatedWeekdays[1] && !activatedWeekdays[2] && !activatedWeekdays[3] && !activatedWeekdays[4] && !activatedWeekdays[5] && activatedWeekdays[6])
			return "Every Weekends";

		if (_weekdayText.Length > 0)
			_weekdayText = _weekdayText.Substring(0, _weekdayText.Length - 2);

		return _weekdayText;
	}

    public static string ConvertWeekdayIntToString(string weekdayInt)
	{
		bool[] _weekdayInt = new bool[7];
		for (int i = 0; i < weekdayInt.Length; i++)
		{
			if (weekdayInt[i] == '1')
				_weekdayInt[i] = true;
			else
				_weekdayInt[i] = false;
		}

        return ConvertWeekdayIntToString(_weekdayInt);
	}
}
