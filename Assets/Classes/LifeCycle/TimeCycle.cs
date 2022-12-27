using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this class is responsible for the time cycle of the game including the daily tasks wait time
public class TimeCycle
{
	public TimeCycleItem[] timeCycleItems;
}

[System.Serializable]
public class TimeCycleItem
{
    public string name;
    // start time of the time cycle item
    public int startTime;
    // end time of the time cycle item
    public int endTime;
}