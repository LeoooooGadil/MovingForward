using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Android;
public static class SaveSystem
{
	public static void PermissionCheck()
	{
		if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
		{
			Debug.Log("Requesting permission to write to external storage...");
			Debug.Log("Permission.ExternalStorageWrite: " + Permission.ExternalStorageWrite);
			Permission.RequestUserPermission(Permission.ExternalStorageWrite);
		}

		if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
		{
			Debug.Log("Requesting permission to read from external storage...");
			Permission.RequestUserPermission(Permission.ExternalStorageRead);
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
		PermissionCheck();

		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	#region playerSchedule

	public static string playerSchedulePath = Application.persistentDataPath;
	public static string playerScheduleName = "playerSchedule.dat";

	public static void SavePlayerSchedule(PlayerSchedule playerSchedule, string savename = "")
	{
		string path = playerSchedulePath + "/" + (savename == "" ? playerScheduleName : savename);

		Save(path, new PlayerScheduleData(playerSchedule));
	}

	public static PlayerScheduleData LoadPlayerSchedule(string savename = "")
	{
		string path = playerSchedulePath + "/" + (savename == "" ? playerScheduleName : savename);

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
		resetSaveFile(path);
	}

	#endregion

	#region gameSettings

	public static string gameSettingsPath = Application.persistentDataPath;

	public static void SaveGameSetting(GameSetting gameSetting, string savename = "gameSettings.dat")
	{
		string path = gameSettingsPath + "/" + savename;
		Save(path, new GameSettingData(gameSetting));
	}

	public static GameSettingData LoadGameSetting()
	{
		string path = gameSettingsPath;

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

		resetSaveFile(path);
		resetSaveFile(userpathsetting);
	}

	#endregion

	#region playerProfile

	public static string playerProfilePath = Application.persistentDataPath;

	public static string playerProfileName = "playerProfile.dat";

	public static void SavePlayerProfile(PlayerProfile playerProfile, string savename = "playerProfile.dat")
	{
		string path = playerProfilePath + "/" + savename;

		Save(path, new PlayerProfileData(playerProfile));
	}

	public static PlayerProfileData LoadPlayerProfile(string savename = "playerProfile.dat")
	{
		string path = playerProfilePath + "/" + savename;

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
		resetSaveFile(path);
	}

	#endregion

	#region playerDailyTasks

	public static string playerDailyTasksPath = Application.persistentDataPath;

	public static string playerDailyTasksName = "playerDailyTasks.dat";

	public static void SavePlayerDailyTasks(PlayerDailyTaskList playerDailyTaskList, string savename = "playerDailyTasks.dat")
	{
		string path = playerDailyTasksPath + "/" + savename;

		Save(path, new PlayerDailyTaskListData(playerDailyTaskList));
	}

	public static PlayerDailyTaskListData LoadPlayerDailyTasks(string savename = "playerDailyTasks.dat")
	{
		string path = playerDailyTasksPath + "/" + savename;

		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerDailyTaskListData data = formatter.Deserialize(stream) as PlayerDailyTaskListData;
			stream.Close();

			return data;
		}
		else
		{
			// Debug.LogError("Save file not found in " + playerDailyTasksPath);
			return null;
		}
	}

	public static void resetPlayerDailyTasks()
	{
		string path = playerDailyTasksPath + "/" + playerDailyTasksName;
		resetSaveFile(path);
	}

	#endregion

}

