using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip[] musicClips;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.volume = GameSettingsManager.instance.GetGameSetting().sfxVolume;
        sfxAudioSource.Play();
    }

    public void PlaySFXOneShot(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip, GameSettingsManager.instance.GetGameSetting().sfxVolume);
    }
}
