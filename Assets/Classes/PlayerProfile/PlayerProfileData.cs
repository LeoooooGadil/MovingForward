using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfileData
{
    public string playerName;
    public int playerLevel;
    public float playerExp;
    public bool isPlayerAcceptedTerms;
    public bool isPlayerAddedToCalendar;

    public PlayerProfileData(PlayerProfile _playerProfile)
    {
        playerName = _playerProfile.playerName;
        playerLevel = _playerProfile.playerLevel;
        playerExp = _playerProfile.playerExp;
        isPlayerAcceptedTerms = _playerProfile.isPlayerAcceptedTerms;
        isPlayerAddedToCalendar = _playerProfile.isPlayerAddedToCalendar;
    }

    public PlayerProfileData()
    {
        playerName = "Player";
        playerLevel = 1;
        playerExp = 0;
        isPlayerAcceptedTerms = false;
        isPlayerAddedToCalendar = false;
    }
}
