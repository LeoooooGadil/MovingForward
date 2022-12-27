using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyTaskManager
{
    private DailyTask[] UnfinishedDailyTask;
    private DailyTask[] FinishedDailyTask;

    public DailyTaskManager(string[][] todaysDailyTask)
    {
        UnfinishedDailyTask = new DailyTask[todaysDailyTask.Length];
        for (int i = 0; i < todaysDailyTask.Length; i++)
        {
            UnfinishedDailyTask[i] = new DailyTask();
            UnfinishedDailyTask[i].Name = todaysDailyTask[i][0];
            UnfinishedDailyTask[i].Points = int.Parse(todaysDailyTask[i][1]);
            UnfinishedDailyTask[i].IsCompleted = false;
        }
        FinishedDailyTask = new DailyTask[0];
    }

    public DailyTaskManager(PlayerDailyTaskListData playerDailyTaskListData)
    {
        UnfinishedDailyTask = playerDailyTaskListData.UnfinishedDailyTask;
        FinishedDailyTask = playerDailyTaskListData.FinishedDailyTask;
    }

    public DailyTaskManager() {
        UnfinishedDailyTask = new DailyTask[0];
        FinishedDailyTask = new DailyTask[0];
    }

    //save the daily task list to a file
    public void SaveDailyTaskList()
    {
        PlayerDailyTaskList playerDailyTaskList = new PlayerDailyTaskList(UnfinishedDailyTask, FinishedDailyTask);
        SaveSystem.SavePlayerDailyTasks(playerDailyTaskList);
    }

    //load the daily task list from a file
    public void LoadDailyTaskList()
    {
        PlayerDailyTaskListData playerDailyTaskListData = SaveSystem.LoadPlayerDailyTasks();
        
        if (playerDailyTaskListData != null)
        {
            UnfinishedDailyTask = playerDailyTaskListData.UnfinishedDailyTask;
            FinishedDailyTask = playerDailyTaskListData.FinishedDailyTask;
        }
    }
    
    // get the list of tasks
    public DailyTask[] GetUnfinishedDailyTask()
    {
        return UnfinishedDailyTask;
    }

    public DailyTask[] GetFinishedDailyTask()
    {
        return FinishedDailyTask;
    }

    // get a task by name
    public DailyTask GetDailyTask(string taskName)
    {
        for (int i = 0; i < UnfinishedDailyTask.Length; i++)
        {
            if (UnfinishedDailyTask[i].Name == taskName)
            {
                return UnfinishedDailyTask[i];
            }
        }
        for (int i = 0; i < FinishedDailyTask.Length; i++)
        {
            if (FinishedDailyTask[i].Name == taskName)
            {
                return FinishedDailyTask[i];
            }
        }
        return null;
    }

    // complete a daily task and move it to the finished list of daily tasks
    public void CompleteDailyTask(string taskName)
    {
        for (int i = 0; i < UnfinishedDailyTask.Length; i++)
        {
            if (UnfinishedDailyTask[i].Name == taskName)
            {
                UnfinishedDailyTask[i].IsCompleted = true;

                // move the completed task to the finished list
                DailyTask[] temp = new DailyTask[FinishedDailyTask.Length + 1];
                for (int j = 0; j < FinishedDailyTask.Length; j++)
                {
                    temp[j] = FinishedDailyTask[j];
                }
                temp[FinishedDailyTask.Length] = UnfinishedDailyTask[i];
                FinishedDailyTask = temp;

                // remove the completed task from the unfinished list
                temp = new DailyTask[UnfinishedDailyTask.Length - 1];
                for (int j = 0; j < i; j++)
                {
                    temp[j] = UnfinishedDailyTask[j];
                }
                for (int j = i; j < UnfinishedDailyTask.Length - 1; j++)
                {
                    temp[j] = UnfinishedDailyTask[j + 1];
                }
                UnfinishedDailyTask = temp;

                break;
            }
        }
    }
}
