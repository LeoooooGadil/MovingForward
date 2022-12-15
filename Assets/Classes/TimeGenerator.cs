using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeGenerator
{
	// half a second is 500
	// second is 1000
	// minute is 60 * 1000
	// hour is 60 * 60 * 1000
	// day is 24 * 60 * 60 * 1000
	// week is 7 * 24 * 60 * 60 * 1000
	// month is 30 * 24 * 60 * 60 * 1000
	// year is 365 * 24 * 60 * 60 * 1000

	int time;
	int hours;
	int minutes;
	int seconds;
	string ampm;

	bool is24Hour = false;

	public TimeGenerator(bool is24Hour = false)
	{
		this.time = 0;
		this.hours = 0;
		this.minutes = 0;
		this.seconds = 0;
		this.ampm = "";
		this.is24Hour = is24Hour;
	}

	public void setTime(string time)
	{
		DateTime dt = DateTime.Parse(time);

		int hours = dt.Hour, minutes = dt.Minute, seconds = dt.Second;

		this.time = timeToMilliseconds(hours, minutes, seconds); // milliseconds;

		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;

		if (hours >= 12)
		{
			this.ampm = "PM";
		}
		else
		{
			this.ampm = "AM";
		}
	}

	public int timeToMilliseconds(int hours, int minutes, int seconds)
	{
		return hours * 60 * 60 * 1000 + minutes * 60 * 1000 + seconds * 1000;
	}

	public int timeToMilliseconds(string time)
	{
		DateTime dt = DateTime.Parse(time);

		int hours = dt.Hour, minutes = dt.Minute, seconds = dt.Second;

		return timeToMilliseconds(hours, minutes, seconds);
	}

	public object[] millisecondsToTime(int milliseconds)
	{
		int hours = milliseconds / (60 * 60 * 1000);
		milliseconds -= hours * (60 * 60 * 1000);

		int minutes = milliseconds / (60 * 1000);
		milliseconds -= minutes * (60 * 1000);

		int seconds = milliseconds / 1000;
		milliseconds -= seconds * 1000;

		return new object[] { hours, minutes, seconds, milliseconds };
	}

	public void addTime(int timeDuration)
	{
		// if time exceeds 24 hours dont add it
		if (this.time + timeDuration > 24 * 60 * 60 * 1000)
			return;

		this.time += timeDuration;

		object[] _time = millisecondsToTime(this.time);

		this.hours = (int)_time[0];
		this.minutes = (int)_time[1];
		this.seconds = (int)_time[2];

		if (this.hours > 12)
		{
			this.hours -= 12;
			this.ampm = "PM";
		}
		else
		{
			this.ampm = "AM";
		}
	}

	public void addTime(int hours, int minutes, int seconds)
	{
		addTime(timeToMilliseconds(hours, minutes, seconds));
	}

	public int getHours()
	{
		return this.hours;
	}

	public int getMinutes()
	{
		return this.minutes;
	}

	public int getSeconds()
	{
		return this.seconds;
	}

	public string getAMPM()
	{
		return this.ampm;
	}

	public int getTotalMilliseconds()
	{
		return this.time;
	}
	public int getIntervalCount(int endtime, int interval)
	{
		int count = 0;

		int time = this.time;

		int _interval = interval * 1000;

		while (time < endtime)
		{
			time += _interval;
			count++;
		}

		return count;
	}

	public int getIntervalCount(string endtime, int interval)
	{
		return getIntervalCount(timeToMilliseconds(endtime), interval);
	}
}
