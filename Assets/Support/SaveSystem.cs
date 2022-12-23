using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void createFoldersIfNotExist()
	{
		string[] paths = { playerSchedulePath, gameSettingsPath, playerProfilePath };

		foreach (string path in paths)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
	}

	public static void Save(string path, object data)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(path, FileMode.Create);

		formatter.Serialize(stream, data);
		stream.Close();

		Debug.Log("Saved to " + path);
	}

	public static void resetSaveFile(string path)
	{
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	#region playerSchedule

	public static string playerSchedulePath = Application.persistentDataPath + "/Save";
	public static string playerScheduleName = "playerSchedule.dat";

	public static void SavePlayerSchedule(PlayerSchedule playerSchedule, string savename = "")
	{
		string path = playerSchedulePath + "/" + (savename == "" ? playerScheduleName : savename);
		createFoldersIfNotExist();

		Save(path, new PlayerScheduleData(playerSchedule));
	}

	public static PlayerScheduleData LoadPlayerSchedule(string savename = "")
	{
		string path = playerSchedulePath + "/" + (savename == "" ? playerScheduleName : savename);
		createFoldersIfNotExist();

		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerScheduleData data = formatter.Deserialize(stream) as PlayerScheduleData;
			stream.Close();

			return data;
		}
		else
		{
			// Debug.LogError("Save file not found in " + playerSchedulePath);
			return null;
		}
	}

	public static void resetPlayerSchedule()
	{
		string path = playerSchedulePath + "/" + playerScheduleName;
		createFoldersIfNotExist();

		resetSaveFile(path);
	}

	#endregion

	#region gameSettings

	public static string gameSettingsPath = Application.persistentDataPath + "/Setting";

	public static void SaveGameSetting(GameSetting gameSetting, string savename = "gameSettings.dat")
	{
		string path = gameSettingsPath + "/" + savename;
		createFoldersIfNotExist();

		Save(path, new GameSettingData(gameSetting));
	}

	public static GameSettingData LoadGameSetting()
	{
		string path = gameSettingsPath;
		createFoldersIfNotExist();

		if (File.Exists(path + "/userGameSettings.dat"))
		{
			path += "/userGameSettings.dat";
		}
		else
		{
			path += "/gameSettings.dat";
		}

		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			GameSettingData data = formatter.Deserialize(stream) as GameSettingData;
			stream.Close();

			return data;
		}
		else
		{
			// Debug.LogError("Save file not found in " + gameSettings);
			return null;
		}
	}

	public static void resetGameSettings()
	{
		string path = gameSettingsPath + "/gameSettings.dat";
		string userpathsetting = gameSettingsPath + "/userGameSettings.dat";
		createFoldersIfNotExist();

		resetSaveFile(path);
		resetSaveFile(userpathsetting);
	}

	#endregion

	#region playerProfile

	public static string playerProfilePath = Application.persistentDataPath + "/Save";

	public static string playerProfileName = "playerProfile.dat";

	public static void SavePlayerProfile(PlayerProfile playerProfile, string savename = "playerProfile.dat")
	{
		string path = playerProfilePath + "/" + savename;
		createFoldersIfNotExist();

		Save(path, new PlayerProfileData(playerProfile));
	}

	public static PlayerProfileData LoadPlayerProfile(string savename = "playerProfile.dat")
	{
		string path = playerProfilePath + "/" + savename;
		createFoldersIfNotExist();

		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerProfileData data = formatter.Deserialize(stream) as PlayerProfileData;
			stream.Close();

			return data;
		}
		else
		{
			// Debug.LogError("Save file not found in " + playerProfilePath);
			return null;
		}
	}

	public static void resetPlayerProfile()
	{
		string path = playerProfilePath + "/" + playerProfileName;
		createFoldersIfNotExist();

		resetSaveFile(path);
	}

	#endregion

}

