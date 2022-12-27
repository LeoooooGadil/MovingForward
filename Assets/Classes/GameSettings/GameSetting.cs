using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting
{

    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    public GameSetting(GameSettingProfile _gameSettingProfile)
    {
        masterVolume = _gameSettingProfile.masterVolume;
        musicVolume = _gameSettingProfile.musicVolume;
        sfxVolume = _gameSettingProfile.sfxVolume;
    }

    public GameSetting(GameSettingData _gameSettingData)
    {
        masterVolume = _gameSettingData.masterVolume;
        musicVolume = _gameSettingData.musicVolume;
        sfxVolume = _gameSettingData.sfxVolume;
    }

    public GameSetting()
    {
        masterVolume = 1;
        musicVolume = 1;
        sfxVolume = 1;
    }

    public void SetMasterVolume(float _masterVolume)
    {
        masterVolume = _masterVolume;
    }

    public void SetMusicVolume(float _musicVolume)
    {
        musicVolume = _musicVolume;
    }

    public void SetSFXVolume(float _sfxVolume)
    {
        sfxVolume = _sfxVolume;
    }

    public GameSettingData GetGameSettingData()
    {
        return new GameSettingData(this);
    }
    public string toString()
    {
        Debug.Log("masterVolume: " + masterVolume);
        Debug.Log("musicVolume: " + musicVolume);
        Debug.Log("sfxVolume: " + sfxVolume);

        return "masterVolume: " + masterVolume + " musicVolume: " + musicVolume + " sfxVolume: " + sfxVolume;
    }
}
