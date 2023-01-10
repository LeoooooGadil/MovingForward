using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;

	public AudioSource musicAudioSource;
	public AudioSource sfxAudioSource;

	public AudioClip[] musicClips;
	public AudioClip[] sfxClips;

	public int currentMusicID;

    Camera mainCamera;

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

		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
        mainCamera = Camera.main;
        PlayMusic(0);
	}

	void Update()
	{
		musicAudioSource.volume = GetSoundVolume(GameSettingsManager.instance.GetGameSetting().musicVolume);
		sfxAudioSource.volume = GetSoundVolume(GameSettingsManager.instance.GetGameSetting().sfxVolume);
	}

	// calculate sound volume based on master volume
	public float GetSoundVolume(float soundVolume)
	{
		return soundVolume * GameSettingsManager.instance.GetGameSetting().masterVolume;
	}

	void PlayMusic(int id)
	{
		// MAKE A BETTER SCRIPT INSTEAD OF THIS

		if (musicClips.Length == 0)
		{
			Debug.LogError("NASAN NA YUNG MUSIC CLIPS LAGI NA LANG KAYO MAGSUSUMBONG NG BUGS ");
			return;
		}

        musicAudioSource.clip = musicClips[0];
        musicAudioSource.Play();
	}

	void OnApplicationQuit()
	{
		ANAMusic.release(currentMusicID);
	}

	public void PlaySFX(AudioClip clip)
	{
		sfxAudioSource.clip = clip;
		sfxAudioSource.Play();
	}

	public void PlaySFXOneShot(AudioClip clip)
	{
		sfxAudioSource.PlayOneShot(clip, GameSettingsManager.instance.GetGameSetting().sfxVolume);
	}

	public void PlaySFX(int index)
	{
		if (sfxClips.Length == 0)
		{
			Debug.LogError("No sfx clips found!");
			return;
		}

		sfxAudioSource.clip = sfxClips[index];
		sfxAudioSource.Play();
	}
}
