using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class DailyTaskListController : MonoBehaviour
{
	public DailyTasks dailyTasks;

	public GameObject dailyTaskPrefab;
	public GameObject emptyTaskPrefab;
	public GameObject finishTaskTitlePrefab;
	public GameObject unfinishedTaskTitlePrefab;
	public GameObject dailyTaskContainer;

	public Button resetDailyTaskButton;

	public int numberOfDailyTasks = 3;

	DailyTaskManager dailyTaskManager;

	public TimeSpan remainingTime = new TimeSpan();
	public DailyTasksController dailyTasksController;

	public TMP_Text TMP_DailyTaskRemainingTime;

	void Start()
	{
		Init();
		TimeCycleManager.instance.AddTimeCycleItem("DailyTask", DateTime.Today.AddDays(1).AddHours(8), true); // 8am
		resetDailyTaskButton.onClick.AddListener(ResetDailyTask);
	}

	void Update()
	{
		remainingTime = TimeCycleManager.instance.GetRemainingTime("DailyTask");
		bool isTimeCycleItemFinished = TimeCycleManager.instance.IsTimeCycleItemFinished("DailyTask");

		if (isTimeCycleItemFinished)
		{
			generateRandomDailyTasks();
			TimeCycleManager.instance.ResetTimeCycleItem("DailyTask");
		}

		string time = string.Format("{0:D2}:{1:D2}:{2:D2}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
		TMP_DailyTaskRemainingTime.text = time;
	}

	public void ResetDailyTask()
	{
		generateRandomDailyTasks();
		dailyTasksController.CloseMenu();
	}

	private void Init()
	{
		dailyTaskManager = new DailyTaskManager();

		dailyTaskManager.LoadDailyTaskList();

		if (dailyTaskManager.GetUnfinishedDailyTask().Length == 0 && dailyTaskManager.GetFinishedDailyTask().Length == 0)
		{
			generateRandomDailyTasks();
			return;
		}

		updateDailyTaskList();
	}

	public void CompleteTask(string taskName)
	{
		dailyTaskManager.CompleteDailyTask(taskName);
		PlayerStatisticsManager.instance.xpManager.AddExperience(dailyTaskManager.GetDailyTask(taskName).Points);
		dailyTaskManager.SaveDailyTaskList();

		PlayerStatisticsManager.instance.weeklyStatsManager.AddDailyTaskCompleted();

		if (dailyTaskManager.GetUnfinishedDailyTask().Length == 0)
		{
			SoundManager.instance.PlaySFX(5);
		}
		else
		{
			SoundManager.instance.PlaySFX(6);
		}
	}

	public void updateDailyTaskList()
	{
		foreach (Transform child in dailyTaskContainer.transform)
		{
			Destroy(child.gameObject);
		}

		// if there are no tasks, display emptytask
		if (dailyTaskManager.GetUnfinishedDailyTask().Length == 0 && dailyTaskManager.GetFinishedDailyTask().Length == 0)
		{
			GameObject emptyTaskObject = Instantiate(emptyTaskPrefab, dailyTaskContainer.transform);
		}

		if(dailyTaskManager.GetUnfinishedDailyTask().Length != 0 && dailyTaskManager.GetFinishedDailyTask().Length != 0)
		{
			GameObject unfinishedTaskTitleObject = Instantiate(unfinishedTaskTitlePrefab, dailyTaskContainer.transform);
		}

		foreach (DailyTask dailyTask in dailyTaskManager.GetUnfinishedDailyTask())
		{
			GameObject dailyTaskObject = Instantiate(dailyTaskPrefab, dailyTaskContainer.transform);
			dailyTaskObject.GetComponent<TaskComponent>().taskName = dailyTask.Name;
			dailyTaskObject.GetComponent<TaskComponent>().taskPoints = dailyTask.Points;
			dailyTaskObject.GetComponent<TaskComponent>().taskIsCompleted = dailyTask.IsCompleted;
			dailyTaskObject.GetComponent<TaskComponent>().dailyTaskListController = this;
		}

		if (dailyTaskManager.GetFinishedDailyTask().Length != 0)
		{
			GameObject finishTaskTitleObject = Instantiate(finishTaskTitlePrefab, dailyTaskContainer.transform);
		}

		foreach (DailyTask dailyTask in dailyTaskManager.GetFinishedDailyTask())
		{
			GameObject dailyTaskObject = Instantiate(dailyTaskPrefab, dailyTaskContainer.transform);
			dailyTaskObject.GetComponent<TaskComponent>().taskName = dailyTask.Name;
			dailyTaskObject.GetComponent<TaskComponent>().taskPoints = dailyTask.Points;
			dailyTaskObject.GetComponent<TaskComponent>().taskIsCompleted = dailyTask.IsCompleted;
			dailyTaskObject.GetComponent<TaskComponent>().dailyTaskListController = this;
		}
	}

	public void generateRandomDailyTasks()
	{
		dailyTaskManager = new DailyTaskManager(dailyTasks.GetRandomDailyTasks(numberOfDailyTasks));
		dailyTaskManager.SaveDailyTaskList();
		updateDailyTaskList();
		NotificationSystem.instance.SendNotification("Daily Tasks", "New daily tasks are available!");
	}
}
