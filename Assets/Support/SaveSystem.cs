using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void createFoldersIfNotExist()
	{
		string[] paths = { playerSchedulePath, gameSettingsPath };

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

	public static GameSettingData LoadGameSetting(string savename = "gameSettings.dat")
	{
		string path = gameSettingsPath + "/" + savename;
		createFoldersIfNotExist();

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
		createFoldersIfNotExist();

		resetSaveFile(path);
	}

	#endregion



}

