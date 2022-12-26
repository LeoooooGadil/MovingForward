using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeSceneScript : MonoBehaviour
{
	public string sceneName;
	Button button;

	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(async () => await ChangeScene());
	}

	async Task ChangeScene()
	{
		// if LevelManager instance exists, change scene
		if (GameObject.Find("LevelManager") != null)
		{
			Debug.Log("Changing scene to " + sceneName);
			await LevelManager.instance.LoadScene(sceneName);
		}
	}
}
