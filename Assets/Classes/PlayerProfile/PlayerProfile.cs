
public class PlayerProfile
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

    public PlayerProfile(PlayerProfileData _playerProfileData)
    {

        playerName = _playerProfileData.playerName;
        playerAge = _playerProfileData.playerAge;
        playerLevel = _playerProfileData.playerLevel;
        playerExp = _playerProfileData.playerExp;
        isPlayerAcceptedTerms = _playerProfileData.isPlayerAcceptedTerms;
        isPlayerAddedToCalendar = _playerProfileData.isPlayerAddedToCalendar;

        // Weekly Stats

        dailyTaskCompleted = _playerProfileData.dailyTaskCompleted;
        minigamesCompleted = _playerProfileData.minigamesCompleted;
        breathingExerciseCompleted = _playerProfileData.breathingExerciseCompleted;
    }

    public PlayerProfile()
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

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string _playerName)
    {
        playerName = _playerName;
    }

    public int GetPlayerAge()
    {
        return playerAge;
    }

    public void SetPlayerAge(int _playerAge)
    {
        playerAge = _playerAge;
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public void SetPlayerLevel(int _playerLevel)
    {
        playerLevel = _playerLevel;
    }

    public float GetPlayerExp()
    {
        return playerExp;
    }

    public void SetPlayerExp(float _playerExp)
    {
        playerExp = _playerExp;
    }

    public bool GetIsPlayerAcceptedTerms()
    {
        return isPlayerAcceptedTerms;
    }

    public void SetIsPlayerAcceptedTerms(bool _isPlayerAcceptedTerms)
    {
        isPlayerAcceptedTerms = _isPlayerAcceptedTerms;
    }

    public bool GetIsPlayerAddedToCalendar()
    {
        return isPlayerAddedToCalendar;
    }

    public void SetIsPlayerAddedToCalendar(bool _isPlayerAddedToCalendar)
    {
        isPlayerAddedToCalendar = _isPlayerAddedToCalendar;
    }

    public PlayerProfileData GetPlayerProfileData()
    {
        return new PlayerProfileData(this);
    }

    #region Weekly Stats

    public int GetDailyTaskCompleted()
    {
        return dailyTaskCompleted;
    }

    public void SetDailyTaskCompleted(int _dailyTaskCompleted)
    {
        dailyTaskCompleted = _dailyTaskCompleted;
    }

    public int GetMinigamesCompleted()
    {
        return minigamesCompleted;
    }

    public void SetMinigamesCompleted(int _minigamesCompleted)
    {
        minigamesCompleted = _minigamesCompleted;
    }

    public int GetBreathingExerciseCompleted()
    {
        return breathingExerciseCompleted;
    }

    public void SetBreathingExerciseCompleted(int _breathingExerciseCompleted)
    {
        breathingExerciseCompleted = _breathingExerciseCompleted;
    }

    #endregion
}
