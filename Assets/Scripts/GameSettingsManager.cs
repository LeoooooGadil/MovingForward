using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour
{
	public static GameSettingsManager instance;

    public GameSettingProfile defaultGameSettingProfile;
	public GameSettingProfile gameSettingProfile;

    GameSetting gameSetting;

    [Range(0f, 1f)]
    public float masterVolume;

    [Range(0f, 1f)]
    public float musicVolume;

    [Range(0f, 1f)]
    public float sfxVolume;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

    void Start() {
        gameSettingProfile = defaultGameSettingProfile;
        gameSetting = new GameSetting(gameSettingProfile);

        gameSetting = LoadGameSetting();

        // gameSetting.toString();

        masterVolume = gameSetting.masterVolume;
        musicVolume = gameSetting.musicVolume;
        sfxVolume = gameSetting.sfxVolume;
    }

    void Update() {
        if(masterVolume != gameSetting.masterVolume)
        {
            SetMasterVolume(masterVolume);
        }

        if(musicVolume != gameSetting.musicVolume)
        {
            SetMusicVolume(musicVolume);
        }

        if(sfxVolume != gameSetting.sfxVolume)
        {
            SetSFXVolume(sfxVolume);
        }
    }

    public void SetMasterVolume(float _masterVolume)
    {
        gameSetting.SetMasterVolume(_masterVolume);
    }

    public void SetMusicVolume(float _musicVolume)
    {
        gameSetting.SetMusicVolume(_musicVolume);
    }

    public void SetSFXVolume(float _sfxVolume)
    {
        gameSetting.SetSFXVolume(_sfxVolume);
    }

    public GameSetting GetGameSetting()
    {
        return gameSetting;
    }

    public void SaveGameSetting()
    {
        GameSetting _savedGameSetting = LoadGameSetting();
        
        if(_savedGameSetting != null)
        {
            if(_savedGameSetting.toString() != new GameSetting(defaultGameSettingProfile).toString())
            {
                
            }
        }

        SaveSystem.SaveGameSetting(gameSetting);
    }

    public GameSetting LoadGameSetting()
    {
        GameSettingData data = SaveSystem.LoadGameSetting();
        if (data != null)
        {
            return new GameSetting(data);
        }

        return new GameSetting(defaultGameSettingProfile);
    }
}
