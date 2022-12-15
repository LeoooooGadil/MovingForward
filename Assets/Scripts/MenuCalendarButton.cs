using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCalendarButton : MonoBehaviour
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
        ChangeScene(sceneName);
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("changing scene to " + sceneName);
        PlaySound();
        LevelManager.instance.LoadScene(sceneName);
    }

    private void PlaySound()
    {
        if (buttonClickSound != null)
        {
            SoundManager.instance.PlaySFXOneShot(buttonClickSound);
        }
    }
}
