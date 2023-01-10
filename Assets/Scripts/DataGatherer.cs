using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static TimeCycleManager;

public class DataGatherer : MonoBehaviour
{
	string playerData = "";
	string weeklyData = "";
	string gameData = "";

	public TMP_Text playerDataText;
	public TMP_Text weeklyDataText;
	public TMP_Text gameDataText;

	// Update is called once per frame
	void Update()
	{
		// player data
		playerData = "";
		PlayerProfileData playerProfileData = SaveSystem.LoadPlayerProfile();
		if (playerProfileData != null)
		{
			PlayerProfile playerProfile = new PlayerProfile(playerProfileData);
			playerData += "Player Name:   " + playerProfile.playerName + "\n";
			playerData += "Player Age:  " + playerProfile.playerAge + "\n";
			playerData += "Player Level:   " + playerProfile.playerLevel + "\n";
			playerData += "Player Experience:   " + playerProfile.playerExp + "\n";
			playerData += "is Player Accepted Terms:   " + playerProfile.isPlayerAcceptedTerms + "\n";
			playerData += "is Player A New Player:   " + playerProfile.isPlayerAddedToCalendar + "\n";
		}
		else
		{
			playerData = "No player data found";
		}







		// weekly data 
		weeklyData = "";

		if (playerProfileData != null)
		{
			PlayerProfile playerProfile = new PlayerProfile(playerProfileData);
			weeklyData += "DailyTask Completed:   " + playerProfile.dailyTaskCompleted + "\n";
			weeklyData += "Minigames Completed:   " + playerProfile.minigamesCompleted + "\n";
			weeklyData += "Breathing Exercise :   " + playerProfile.breathingExerciseCompleted + "\n";
		}
		else
		{
			weeklyData += "DailyTask Completed:   " + 0 + "\n";
			weeklyData += "Minigames Completed:   " + 0 + "\n";
			weeklyData += "Breathing Exercise :   " + 0 + "\n";
		}

		// game data
		gameData = "";
		gameData += "Game Version:   " + Application.version + "\n";
		gameData += "Game Build:   " + Application.buildGUID + "\n";
		gameData += "Game Platform:   " + Application.platform + "\n";
		gameData += "Game System Language:   " + Application.systemLanguage + "\n";
		gameData += "Game Target Frame Rate:   " + Application.targetFrameRate + "\n";
		gameData += "Game Unity Version:   " + Application.unityVersion + "\n";


		GameInformationData gameInformationData = SaveSystem.LoadGameInformation();
		if (gameInformationData != null)
		{
			GameInformation gameInformation = new GameInformation(gameInformationData);

			gameData += "Current Scenery Index:   " + gameInformation.currentSceneryIndex + "\n";

			gameData += "\nTimeCycles:\n";
			foreach (TimeCycleItem timeCycleItem in gameInformation.timeCycleItems)
			{
				System.TimeSpan remainingTime = timeCycleItem.timeToStop - System.DateTime.Now;
				string time = string.Format("{0:D2}:{1:D2}:{2:D2}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
				gameData += "   " + timeCycleItem.name + ":   " + time + " remaining \n";
			}

		}
		else
		{
			gameData += "\nNo game data found";
		}

		playerDataText.text = playerData;
		weeklyDataText.text = weeklyData;
		gameDataText.text = gameData;
	}
}
