using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeeklyStatsManager : MonoBehaviour
{
    public int dailyTaskCompleted = 0;
    public int minigamesCompleted = 0;
    public int breathingExerciseCompleted = 0;

    public void Start()
    {
        PlayerProfileData data = SaveSystem.LoadPlayerProfile();
        if (data != null)
        {
            PlayerProfile profile = new PlayerProfile(data);

            dailyTaskCompleted = profile.dailyTaskCompleted;
            minigamesCompleted = profile.minigamesCompleted;
            breathingExerciseCompleted = profile.breathingExerciseCompleted;
        }
    }

    public void SavePlayerStatistic()
    {
        PlayerProfileData data = SaveSystem.LoadPlayerProfile();
        if (data != null)
        {
            PlayerProfile profile = new PlayerProfile(data);

            profile.dailyTaskCompleted = dailyTaskCompleted;
            profile.minigamesCompleted = minigamesCompleted;
            profile.breathingExerciseCompleted = breathingExerciseCompleted;

            SaveSystem.SavePlayerProfile(profile);
        }
    }

    public void ResetWeeklyStats()
    {
        dailyTaskCompleted = 0;
        minigamesCompleted = 0;
        breathingExerciseCompleted = 0;
    }

    public void AddDailyTaskCompleted()
    {
        dailyTaskCompleted++;

        SavePlayerStatistic();
    }

    public void AddMinigamesCompleted()
    {
        minigamesCompleted++;

        SavePlayerStatistic();
    }

    public void AddBreathingExerciseCompleted()
    {
        breathingExerciseCompleted++;
        
        SavePlayerStatistic();
    }

    public int GetDailyTaskCompleted()
    {
        return dailyTaskCompleted;
    }

    public int GetMinigamesCompleted()
    {
        return minigamesCompleted;
    }

    public int GetBreathingExerciseCompleted()
    {
        return breathingExerciseCompleted;
    }

    public void SetDailyTaskCompleted(int _dailyTaskCompleted)
    {
        dailyTaskCompleted = _dailyTaskCompleted;

        SavePlayerStatistic();
    }

    public void SetMinigamesCompleted(int _minigamesCompleted)
    {
        minigamesCompleted = _minigamesCompleted;

        SavePlayerStatistic();
    }

    public void SetBreathingExerciseCompleted(int _breathingExerciseCompleted)
    {
        breathingExerciseCompleted = _breathingExerciseCompleted;

        SavePlayerStatistic();
    }
}
