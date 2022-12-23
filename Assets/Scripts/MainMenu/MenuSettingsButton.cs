using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingsButton : MonoBehaviour
{
	public string sceneName = "Settings";
	public AudioClip buttonClickSound;

	Button btn;

	void Start()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		ChangeScene();
	}

	public async void ChangeScene()
	{
		Debug.Log("changing scene to " + sceneName);
		PlaySound(buttonClickSound);
		await LevelManager.instance.LoadScene(sceneName);
	}

	private void PlaySound(AudioClip clip)
	{
		if (clip != null)
		{
			SoundManager.instance.PlaySFXOneShot(clip);
		}
	}

}
