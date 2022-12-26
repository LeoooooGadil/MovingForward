using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Daily Task List", menuName = "Moving Forward/DailyTask/New Event Task List", order = 1)]
public class DailyTasks : ScriptableObject
{
	// daily tasks and their points values are stored in a list separated by a comma
	// string format: "task, points"

	[SerializeField]
	public List<string> _dailyTasks = new List<string>();

	private string[][] arrangedDailyTasks()
	{
		string[][] tasksAndPoints = new string[_dailyTasks.Count][];

		for (int i = 0; i < _dailyTasks.Count; i++)
		{
			tasksAndPoints[i] = _dailyTasks[i].Split(',');

			//remove whitespace
			tasksAndPoints[i][0] = tasksAndPoints[i][0].Trim();
			tasksAndPoints[i][1] = tasksAndPoints[i][1].Trim();

			//convert points to int
			int points = int.Parse(tasksAndPoints[i][1]);
		}

		Debug.Log("Tasks: " + tasksAndPoints.Length);

        return tasksAndPoints;
	}

	public string[][] dailyTasks
	{
		get
		{
			return arrangedDailyTasks();
		}
	}

	public string[][] GetRandomDailyTasks(int numberOfTasks)
	{
		string[][] tasksAndPoints = arrangedDailyTasks();

		// shuffle the tasks
		for (int i = 0; i < tasksAndPoints.Length; i++)
		{
			string[] temp = tasksAndPoints[i];
			int randomIndex = Random.Range(i, tasksAndPoints.Length);
			tasksAndPoints[i] = tasksAndPoints[randomIndex];
			tasksAndPoints[randomIndex] = temp;
		}

		// return the first n tasks
		string[][] randomTasks = new string[numberOfTasks][];
		for (int i = 0; i < numberOfTasks; i++)
		{
			randomTasks[i] = tasksAndPoints[i];
		}

		// sort the tasks by points
		for (int i = 0; i < randomTasks.Length; i++)
		{
			for (int j = i + 1; j < randomTasks.Length; j++)
			{
				if (int.Parse(randomTasks[i][1]) < int.Parse(randomTasks[j][1]))
				{
					string[] temp = randomTasks[i];
					randomTasks[i] = randomTasks[j];
					randomTasks[j] = temp;
				}
			}
		}

		Debug.Log("Random tasks: " + randomTasks.Length);

		return randomTasks;
	}
}
