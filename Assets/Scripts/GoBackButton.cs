using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoBackButton : MonoBehaviour
{
    Button btn;
    public AudioClip buttonClickSound;

    public bool isFallback = false;

    public string fallbackSceneName;

    void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        ChangeScene();
    }

    public async void ChangeScene()
    {
        if (isFallback)
        {
            Debug.Log("changing scene to " + fallbackSceneName);
            PlaySound();
            await LevelManager.instance.LoadScene(fallbackSceneName);
            return;
        }

        Debug.Log("changing scene to " + LevelManager.instance.lastSceneName);
        PlaySound();
        await LevelManager.instance.LoadLastScene();
    }

    private void PlaySound()
	{
		if (buttonClickSound != null)
		{
			SoundManager.instance.PlaySFXOneShot(buttonClickSound);
		}
	}
}
