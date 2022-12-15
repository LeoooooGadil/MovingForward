using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingProfile", menuName = "Moving Forward/Settings/GameSettingProfile", order = 0)]
public class GameSettingProfile : ScriptableObject
{
    [Header("Game Settings")]
    [Range(0, 1)]
    public float masterVolume;
    [Range(0, 1)]
    public float musicVolume;
    [Range(0, 1)]
    public float sfxVolume;
}
