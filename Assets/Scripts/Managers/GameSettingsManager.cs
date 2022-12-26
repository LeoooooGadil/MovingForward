using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

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
        // set fps to 60
        Application.targetFrameRate = 60;

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

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

    public void RevertToDefault()
    {
        gameSetting = new GameSetting(defaultGameSettingProfile);
        SaveGameSetting();

        masterVolume = gameSetting.masterVolume;
        musicVolume = gameSetting.musicVolume;
        sfxVolume = gameSetting.sfxVolume;
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
        SaveSystem.SaveGameSetting(gameSetting, "userGameSettings.dat");
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
