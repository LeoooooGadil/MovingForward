using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NewGameScript : MonoBehaviour
{
	public string nextScene;
	public GameObject[] panels;
	IntroductionPanel[] introductionPanels;
	LoadingController loadingController;
	int currentPanel = 0;

	public object[] data;

	void Awake()
	{
		introductionPanels = new IntroductionPanel[panels.Length];
		data = new object[panels.Length];
		loadingController = GetComponent<LoadingController>();

		for (int i = 0; i < panels.Length; i++)
		{
			introductionPanels[i] = panels[i].GetComponent<IntroductionPanel>();
		}

		if (panels.Length == 0)
		{
			Debug.LogError("No panels found");
			return;
		}

		if (nextScene == null)
		{
			Debug.LogError("No next scene found");
			return;
		}

		if (panels.Length != introductionPanels.Length)
			Debug.LogWarning("Number of panels and introduction panels are not equal. (This is not a problem if you don't use introduction panels)");
	}

	void Start()
	{
		updatePanels();
	}

	void updatePanels()
	{
		for (int i = 0; i < panels.Length; i++)
		{
			if (i == currentPanel)
				panels[i].SetActive(true);
			else
				panels[i].SetActive(false);
		}
	}

	async Task Update()
	{
		if (introductionPanels[currentPanel].isPanelFinished)
		{
			introductionPanels[currentPanel].isPanelFinished = false;
			data[currentPanel] = introductionPanels[currentPanel].data ?? null;
			currentPanel++;
			await loadingController.FadeIn();
			if (currentPanel >= panels.Length)
			{
				SaveData();
				await LevelManager.instance.LoadScene(nextScene);
				return;
			}
			updatePanels();
			await loadingController.Wait(0.5f);
			await loadingController.FadeOut();
		}
	}

	void SaveData()
	{
		//remove all nulls from data
		List<object> _data = new List<object>();
		for (int i = 0; i < data.Length; i++)
		{
			if (data[i] != null)
				_data.Add(data[i]);
		}

		bool isTermsAndConditionAccepted = (bool)_data[0];
		string playerName = (string)_data[1];
		int playerAge = (int)_data[2];

		//put collected data into the PlayerProfile data class
		PlayerProfile playerProfile = new PlayerProfile();
		playerProfile.SetPlayerName(playerName);
		playerProfile.SetPlayerAge(playerAge);
		playerProfile.SetPlayerLevel(1);
		playerProfile.SetPlayerExp(0);
		playerProfile.SetIsPlayerAcceptedTerms(true);
		playerProfile.SetIsPlayerAddedToCalendar(false);

		//save the data
		SaveSystem.SavePlayerProfile(playerProfile);
	}
}
