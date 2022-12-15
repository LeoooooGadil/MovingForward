using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayButton : MonoBehaviour
{
    Button btn;

    public string sceneNewGameName;
    public string sceneContinueGameName;
    public bool isContinueGame = false;

    public AudioClip buttonClickSound;

    void Start() {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (isContinueGame)
        {
            ChangeScene(sceneContinueGameName);
        }
        else
        {
            ChangeScene(sceneNewGameName);
        }
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
