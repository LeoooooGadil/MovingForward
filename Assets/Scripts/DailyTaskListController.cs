using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public DailyTasksController dailyTasksController;

    void Start()
	{
		Init();
        resetDailyTaskButton.onClick.AddListener(ResetDailyTask);
    }

    public void ResetDailyTask() {
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

    public void CompleteTask(string taskName) {
        dailyTaskManager.CompleteDailyTask(taskName);
        PlayerStatisticsManager.instance.xpManager.AddExperience(dailyTaskManager.GetDailyTask(taskName).Points);
        dailyTaskManager.SaveDailyTaskList();

        if(dailyTaskManager.GetUnfinishedDailyTask().Length == 0) {
            SoundManager.instance.PlaySFX(5);
        } else {
            SoundManager.instance.PlaySFX(6);
        }
    }

	public void updateDailyTaskList() {
        foreach (Transform child in dailyTaskContainer.transform) {
            Destroy(child.gameObject);
        }

        // if there are no tasks, display emptytask
        if (dailyTaskManager.GetUnfinishedDailyTask().Length == 0 && dailyTaskManager.GetFinishedDailyTask().Length == 0) {
            GameObject emptyTaskObject = Instantiate(emptyTaskPrefab, dailyTaskContainer.transform);
        }

        foreach (DailyTask dailyTask in dailyTaskManager.GetUnfinishedDailyTask()) {
            GameObject dailyTaskObject = Instantiate(dailyTaskPrefab, dailyTaskContainer.transform);
            dailyTaskObject.GetComponent<TaskComponent>().taskName = dailyTask.Name;
            dailyTaskObject.GetComponent<TaskComponent>().taskPoints = dailyTask.Points;
            dailyTaskObject.GetComponent<TaskComponent>().taskIsCompleted = dailyTask.IsCompleted;
            dailyTaskObject.GetComponent<TaskComponent>().dailyTaskListController = this;
        }
        
        if(dailyTaskManager.GetFinishedDailyTask().Length != 0) {
            GameObject finishTaskTitleObject = Instantiate(finishTaskTitlePrefab, dailyTaskContainer.transform);
        }

        foreach (DailyTask dailyTask in dailyTaskManager.GetFinishedDailyTask()) {
            GameObject dailyTaskObject = Instantiate(dailyTaskPrefab, dailyTaskContainer.transform);
            dailyTaskObject.GetComponent<TaskComponent>().taskName = dailyTask.Name;
            dailyTaskObject.GetComponent<TaskComponent>().taskPoints = dailyTask.Points;
            dailyTaskObject.GetComponent<TaskComponent>().taskIsCompleted = dailyTask.IsCompleted;
            dailyTaskObject.GetComponent<TaskComponent>().dailyTaskListController = this;
        }
    }

    public void generateRandomDailyTasks() {
        dailyTaskManager = new DailyTaskManager(dailyTasks.GetRandomDailyTasks(numberOfDailyTasks));
        dailyTaskManager.SaveDailyTaskList();
        updateDailyTaskList();
    }
}
