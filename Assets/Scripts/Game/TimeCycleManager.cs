using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycleManager : MonoBehaviour
{
	// A class that represents a time cycle item
	[Serializable]
	public class TimeCycleItem
	{
		public string name;
		public DateTime timeToStop;
		public bool isFinishedCountingDown;
		public bool isDaily;
	}

	// The instance of the TimeCycleManager
	public static TimeCycleManager instance;

	// The list of time cycle items
	private List<TimeCycleItem> timeCycleItems = new List<TimeCycleItem>();

	private void Awake()
	{
		// Check if the instance is null
		if (instance == null)
		{
			// Set the instance to this
			instance = this;
		}
		else
		{
			// Destroy this instance
			Destroy(gameObject);
		}

		
	}

	private void Start()
	{
		// Load the list of time cycle items from a file
		GameInformationData gameInformationData = SaveSystem.LoadGameInformation();
		if (gameInformationData != null)
		{
			timeCycleItems = gameInformationData.timeCycleItems;
		}
		else
		{
			timeCycleItems = new List<TimeCycleItem>();
		}

		// Start the SaveTimeCycleItems coroutine
		StartCoroutine(SaveTimeCycleItems());
	}

	// Update is called once per frame
	void Update()
	{
		if (timeCycleItems == null)
			return;

		// Update the remaining time of all time cycle items
		foreach (TimeCycleItem item in timeCycleItems)
		{
			TimeSpan remainingTime = item.timeToStop - DateTime.Now;

			// Check if the item has finished counting down
			if (remainingTime.TotalSeconds <= 0)
			{
				item.isFinishedCountingDown = true;

				// Check if the item should be recursive
				if (item.isDaily)
				{
					// Reset the time to stop
					item.timeToStop = item.timeToStop.AddDays(1);
				}
			}
		}
	}

	// Save the list of time cycle items to a file
	IEnumerator SaveTimeCycleItems()
	{
		while (true)
		{
			// Save the list of time cycle items to a file
			yield return new WaitForSeconds(5);

			GameInformationData gameInformationData = SaveSystem.LoadGameInformation();
			
			if(gameInformationData != null)
			{
				gameInformationData.timeCycleItems = timeCycleItems;
				SaveSystem.SaveGameInformation(new GameInformation(gameInformationData));
			}
			else
			{
				GameInformation gameInformation = new GameInformation();
				gameInformation.timeCycleItems = timeCycleItems;
				SaveSystem.SaveGameInformation(gameInformation);
			}

			Debug.Log("Saved time cycle items");

		}
	}

	// Add a new time cycle item to the list
	public void AddTimeCycleItem(string name, DateTime timeToStop, bool isDaily)
	{
		// Check if the time cycle item already exists
		if (timeCycleItems != null)
		{
			foreach (TimeCycleItem item in timeCycleItems)
			{
				if (item.name == name)
				{
					Debug.Log("Time cycle item already exists");
					return;
				}
			}
		}

		TimeCycleItem newItem = new TimeCycleItem();
		newItem.name = name;
		newItem.timeToStop = timeToStop;
		newItem.isDaily = isDaily;
		timeCycleItems.Add(newItem);
	}

	// Delete a time cycle item from the list
	public void DeleteTimeCycleItem(string name)
	{
		if (timeCycleItems == null)
			return;

		foreach (TimeCycleItem item in timeCycleItems)
		{
			if (item.name == name)
			{
				timeCycleItems.Remove(item);
				return;
			}
		}
	}

	public System.TimeSpan GetRemainingTime(string name)
	{
		if (timeCycleItems == null)
			return new TimeSpan(0);

		foreach (TimeCycleItem item in timeCycleItems)
		{
			if (item.name == name)
			{
				return item.timeToStop - DateTime.Now;
			}
		}
		return new TimeSpan(0);
	}

	public bool IsTimeCycleItemFinished(string name)
	{
		if (timeCycleItems == null)
			return false;

		foreach (TimeCycleItem item in timeCycleItems)
		{
			if (item.name == name)
			{
				return item.isFinishedCountingDown;
			}
		}
		return false;
	}

	public void ResetTimeCycleItem(string name)
	{
		if (timeCycleItems == null)
			return;

		foreach (TimeCycleItem item in timeCycleItems)
		{
			if (item.name == name)
			{
				item.isFinishedCountingDown = false;
				return;
			}
		}
	}
}
