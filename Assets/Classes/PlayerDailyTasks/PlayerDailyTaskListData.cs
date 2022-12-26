using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDailyTaskListData
{
    [SerializeField]
	public DailyTask[] UnfinishedDailyTask;
    [SerializeField]
    public DailyTask[] FinishedDailyTask;

    public PlayerDailyTaskListData(DailyTask[] unfinishedDailyTask, DailyTask[] finishedDailyTask)
    {
        UnfinishedDailyTask = unfinishedDailyTask;
        FinishedDailyTask = finishedDailyTask;
    }

    public PlayerDailyTaskListData(PlayerDailyTaskList playerDailyTaskList)
    {
        UnfinishedDailyTask = playerDailyTaskList.GetUnfinishedDailyTask();
        FinishedDailyTask = playerDailyTaskList.GetFinishedDailyTask();
    }
}
