using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
	public Slider musicSlider;
	public Slider sfxSlider;
	public Slider masterSlider;

	public Button saveButton;
	public Button revertButton;
	public Button goBackButton;

	float lastMasterVolume;
	float lastMusicVolume;
	float lastSFXVolume;

	void Start()
	{
		Load();

		saveButton.onClick.AddListener(Save);
		revertButton.onClick.AddListener(Revert);
		goBackButton.onClick.AddListener(GoBack);

		lastMasterVolume = GameSettingsManager.instance.masterVolume;
		lastMusicVolume = GameSettingsManager.instance.musicVolume;
		lastSFXVolume = GameSettingsManager.instance.sfxVolume;
	}

	void Update()
	{
		GameSettingsManager.instance.musicVolume = musicSlider.value;
		GameSettingsManager.instance.sfxVolume = sfxSlider.value;
		GameSettingsManager.instance.masterVolume = masterSlider.value;

		UpdateSliders();

		if (lastMasterVolume != GameSettingsManager.instance.masterVolume ||
			lastMusicVolume != GameSettingsManager.instance.musicVolume ||
			lastSFXVolume != GameSettingsManager.instance.sfxVolume)
		{
			saveButton.interactable = true;
		}
		else
		{
			saveButton.interactable = false;
		}
	}

	void UpdateSliders()
	{
		GameSettingsManager.instance.SetMasterVolume(masterSlider.value);
		GameSettingsManager.instance.SetSFXVolume(sfxSlider.value);
		GameSettingsManager.instance.SetMusicVolume(musicSlider.value);
	}

	void Save()
	{
		GameSettingsManager.instance.SaveGameSetting();

		lastMasterVolume = GameSettingsManager.instance.masterVolume;
		lastMusicVolume = GameSettingsManager.instance.musicVolume;
		lastSFXVolume = GameSettingsManager.instance.sfxVolume;

		// await LevelManager.instance.LoadLastScene();
	}

	void Revert()
	{
		GameSettingsManager.instance.RevertToDefault();
	}

	async void GoBack()
	{
		Revert();
		await LevelManager.instance.LoadLastScene();
	}

	void Load()
	{
		musicSlider.value = GameSettingsManager.instance.musicVolume;
		sfxSlider.value = GameSettingsManager.instance.sfxVolume;
		masterSlider.value = GameSettingsManager.instance.masterVolume;
	}
}
