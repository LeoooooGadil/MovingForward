using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventFormCancel : MonoBehaviour
{
   Button btn;

    public string sceneName;
    public AudioClip buttonClickSound;

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
        Debug.Log("changing scene to " + sceneName);
        PlaySound();
        await LevelManager.instance.LoadScene(sceneName);
    }

    private void PlaySound()
    {
        if (buttonClickSound != null)
        {
            SoundManager.instance.PlaySFXOneShot(buttonClickSound);
        }
    }
}
