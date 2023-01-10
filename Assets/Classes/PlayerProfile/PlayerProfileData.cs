using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfileData
{
    public string playerName;
    public int playerAge;
    public int playerLevel;
    public float playerExp;
    public bool isPlayerAcceptedTerms;
    public bool isPlayerAddedToCalendar;

    // Weekly Stats

    public int dailyTaskCompleted = 0;
    public int minigamesCompleted = 0;
    public int breathingExerciseCompleted = 0;

    public PlayerProfileData(PlayerProfile _playerProfile)
    {
        playerName = _playerProfile.playerName;
        playerAge = _playerProfile.playerAge;
        playerLevel = _playerProfile.playerLevel;
        playerExp = _playerProfile.playerExp;
        isPlayerAcceptedTerms = _playerProfile.isPlayerAcceptedTerms;
        isPlayerAddedToCalendar = _playerProfile.isPlayerAddedToCalendar;

        // Weekly Stats

        dailyTaskCompleted = _playerProfile.dailyTaskCompleted;
        minigamesCompleted = _playerProfile.minigamesCompleted;
        breathingExerciseCompleted = _playerProfile.breathingExerciseCompleted;

    }

    public PlayerProfileData()
    {
        playerName = "Player";
        playerAge = 0;
        playerLevel = 1;
        playerExp = 0;
        isPlayerAcceptedTerms = false;
        isPlayerAddedToCalendar = false;

        // Weekly Stats

        dailyTaskCompleted = 0;
        minigamesCompleted = 0;
        breathingExerciseCompleted = 0;
    }
}
