using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDailyTaskList
{
    public DailyTask[] UnfinishedDailyTask;
    public DailyTask[] FinishedDailyTask;

    public PlayerDailyTaskList(DailyTask[] unfinishedDailyTask, DailyTask[] finishedDailyTask)
    {
        UnfinishedDailyTask = unfinishedDailyTask;
        FinishedDailyTask = finishedDailyTask;
    }

    public DailyTask[] GetUnfinishedDailyTask()
    {
        return UnfinishedDailyTask;
    }

    public DailyTask[] GetFinishedDailyTask()
    {
        return FinishedDailyTask;
    }
}
