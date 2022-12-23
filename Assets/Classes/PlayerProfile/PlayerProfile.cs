
public class PlayerProfile
{
    public string playerName;
    public int playerLevel;
    public float playerExp;
    public bool isPlayerAcceptedTerms;
    public bool isPlayerAddedToCalendar;

    public PlayerProfile(PlayerProfileData _playerProfileData)
    {

        playerName = _playerProfileData.playerName;
        playerLevel = _playerProfileData.playerLevel;
        playerExp = _playerProfileData.playerExp;
        isPlayerAcceptedTerms = _playerProfileData.isPlayerAcceptedTerms;
    }

    public PlayerProfile()
    {
        playerName = "Player";
        playerLevel = 1;
        playerExp = 0;
        isPlayerAcceptedTerms = false;
        isPlayerAddedToCalendar = false;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string _playerName)
    {
        playerName = _playerName;
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
}
