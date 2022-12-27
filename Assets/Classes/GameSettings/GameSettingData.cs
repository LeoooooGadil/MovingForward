using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSettingData
{
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    public GameSettingData(GameSetting _gameSetting)
    {
        masterVolume = _gameSetting.masterVolume;
        musicVolume = _gameSetting.musicVolume;
        sfxVolume = _gameSetting.sfxVolume;
    }
}
