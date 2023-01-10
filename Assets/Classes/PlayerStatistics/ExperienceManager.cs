using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
	public int currentLevel = 1;
	public float currentExperience = 0;
	public float experienceToNextLevelMultiplier = .3f;
	public float experienceToNextLevel = 100;

	public TMP_Text levelText;

    [InspectorButton("AddRandomExperience")]
    public bool _AddRandomExperience = false;

    [InspectorButton("ResetExperience")]
    public bool _ResetExperience = false;

	public void Start()
	{
		currentLevel = 1;
		currentExperience = 0;

		PlayerProfileData data = SaveSystem.LoadPlayerProfile();
		if (data != null)
		{
			PlayerProfile profile = new PlayerProfile(data);

			currentLevel = profile.playerLevel;
			currentExperience = profile.playerExp;
		}

		calculateExperienceToNextLevel();
	}

	public void Update()
	{
		if(levelText != null)
			levelText.text = currentLevel.ToString();
	}

    public void SavePlayerProfile()
    {
        PlayerProfileData data = SaveSystem.LoadPlayerProfile();
		if (data != null)
		{
			PlayerProfile profile = new PlayerProfile(data);

			profile.playerLevel = currentLevel;
			profile.playerExp = currentExperience;

			SaveSystem.SavePlayerProfile(profile);
		}
    }

	public void calculateExperienceToNextLevel()
	{
		// I DONT KNOW HOW TO DO ALGORITHMS SO I JUST MADE THIS UP LOL
		experienceToNextLevel = (currentLevel * (experienceToNextLevelMultiplier) * 100) * .6f;
	}

    public void AddRandomExperience()
    {
        float randomExp = Random.Range(0, 50);
        AddExperience(randomExp);
    }

    public void ResetExperience()
    {
        currentLevel = 1;
        currentExperience = 0;
        calculateExperienceToNextLevel();

        SavePlayerProfile();
    }

	public void AddExperience(float experience)
	{
		currentExperience += experience;
		if (currentExperience >= experienceToNextLevel)
			LevelUp();

        SavePlayerProfile();
	}

	public void LevelUp()
	{
		currentExperience -= experienceToNextLevel;
		currentLevel++;
		calculateExperienceToNextLevel();
	}
}
