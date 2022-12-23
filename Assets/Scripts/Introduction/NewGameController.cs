// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using System.Threading.Tasks;

// public class NewGameController : MonoBehaviour
// {

// 	public string sceneName = "Calendar";

// 	#region SceneControllerVariables

// 	[Header("Scene Controller")]
// 	public Image fadeImage;
// 	public GameObject[] scenes;
// 	int currentScene = 0;

// 	[InspectorButton("MakeNextScene")]
// 	public bool NextScene;

// 	[InspectorButton("MakePreviousScene")]
// 	public bool PreviousScene;

// 	#endregion

// 	#region NewGameControllerVariables

// 	[Header("New Game Controller")]
// 	public TermsAndConditionController termsAndConditionController;
// 	public IntroductionPlayer introductionPlayer;
// 	public ChooseYourNameController chooseYourNameController;
	
// 	public WelcomeWagonPlayer welcomeWagonPlayer;
// 	public bool isTermsAccepted = false;
// 	public bool isIntroductionDone = false;
// 	public bool isNameChosen = false;
// 	public bool isWelcomeWagonDone = false;
// 	public string playerName;

// 	#endregion

// 	void Start()
// 	{
// 		initSceneController();
// 	}

// 	async Task Update()
// 	{
// 		switch (currentScene)
// 		{
// 			case 0:
// 				if (termsAndConditionController.isTermsAccepted)
// 				{
// 					termsAndConditionController.isTermsAccepted = false;
// 					isTermsAccepted = true;
// 					await MakeNextScene();
// 				}
// 				break;
// 			case 1:
// 				if (introductionPlayer.isDone)
// 				{	
// 					introductionPlayer.isDone = false;
// 					isIntroductionDone = true;
// 					await MakeNextScene();
// 				}
// 				break;
// 			case 2:
// 				if (chooseYourNameController.isNameChosen)
// 				{
// 					chooseYourNameController.isNameChosen = false;
// 					isNameChosen = true;
// 					playerName = chooseYourNameController.playerName;
// 					SavePlayerProfile();
// 					await MakeNextScene();
// 				}
// 				break;
// 			case 3:
// 				if (welcomeWagonPlayer.isDone)
// 				{
// 					Debug.Log("Welcome Wagon Done");
// 					welcomeWagonPlayer.isDone = false;
// 					isWelcomeWagonDone = true;
// 					TaskOnClick();
// 				}
// 				break;
// 		}
// 	}

// 	public void SavePlayerProfile ()
// 	{
// 		PlayerProfile playerProfile = new PlayerProfile();
// 		playerProfile.SetPlayerName(playerName);
// 		playerProfile.SetPlayerLevel(1);
// 		playerProfile.SetPlayerExp(0);
// 		playerProfile.SetIsPlayerAcceptedTerms(isTermsAccepted);
// 		playerProfile.SetIsPlayerAddedToCalendar(false);

// 		SaveSystem.SavePlayerProfile(playerProfile);
// 	}

// 	void TaskOnClick()
// 	{
// 		ChangeScene();
// 	}

// 	public async void ChangeScene()
// 	{
// 		Debug.Log("changing scene to " + sceneName);
// 		await LevelManager.instance.LoadScene(sceneName);
// 	}

// 	#region SceneChanger

// 	void initSceneController()
// 	{

// 		for (int i = 0; i < scenes.Length; i++)
// 		{
// 			scenes[i].SetActive(false);
// 		}

// 		updateDisplay();
// 		fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
// 	}

// 	void updateDisplay()
// 	{
// 		for (int i = 0; i < scenes.Length; i++)
// 		{
// 			scenes[i].SetActive(false);
// 		}
// 		scenes[currentScene].SetActive(true);
// 	}

// 	async Task MakeNextScene()
// 	{
// 		Debug.Log("Next Scene");
// 		if (currentScene < scenes.Length - 1)
// 		{
// 			await FadeIn();
// 			currentScene++;
// 			if (currentScene > scenes.Length - 1)
// 			{
// 				currentScene = scenes.Length - 1;
// 			}
// 			await Wait(0.5f);
// 			updateDisplay();
// 			await FadeOut();
// 		}
// 	}

// 	async Task MakePreviousScene()
// 	{
// 		Debug.Log("Previous Scene");
// 		if (currentScene > 0)
// 		{
// 			await FadeIn();
// 			currentScene--;
// 			if (currentScene < 0)
// 			{
// 				currentScene = 0;
// 			}
// 			await Wait(0.5f);
// 			updateDisplay();
// 			await FadeOut();
// 		}
// 	}

// 	private async Task Wait(float seconds)
// 	{
// 		await Task.Delay((int)(seconds * 1000));
// 	}

// 	public async Task FadeIn()
// 	{
// 		fadeImage.raycastTarget = true;
// 		fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
// 		fadeImage.canvasRenderer.SetAlpha(0.0f);
// 		fadeImage.CrossFadeAlpha(1.0f, 0.3f, false);
// 		await Task.Delay(300);
// 	}

// 	public async Task FadeOut()
// 	{
// 		fadeImage.canvasRenderer.SetAlpha(1.0f);
// 		fadeImage.CrossFadeAlpha(0.0f, 0.5f, false);
// 		await Task.Delay(300);
// 		fadeImage.raycastTarget = false;
// 	}

// 	#endregion
// }
