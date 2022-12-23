using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeSceneScript : MonoBehaviour
{
	public Object sceneObject;
	string sceneName;
	Button button;

	void OnValidate()
	{
		SaveCheckerScript _saveCheckerScript = GetComponent<SaveCheckerScript>();

		if (_saveCheckerScript == null)
		{
			if (sceneObject == null)
			{
				Debug.LogError("Scene object is null");
				return;
			}
		}
	}

	void Start()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(async () => await ChangeScene());
	}

	void Update()
	{
		if (sceneObject != null)
		{
			sceneName = sceneObject.name;
		}
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
