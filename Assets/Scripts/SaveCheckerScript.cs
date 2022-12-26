using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(ChangeSceneScript))]
public class SaveCheckerScript : MonoBehaviour
{
    public string defaultSceneName;
    public string fallbackSceneName;

    string sceneName_1;
    string sceneName_2;

    ChangeSceneScript changeSceneScript;


    void OnValidate()
    {
        if (defaultSceneName == null)
        {
            Debug.LogError("Scene name 1 is null. Please enter a scene name.");
            return;
        }

        if (fallbackSceneName == null)
        {
            Debug.LogError("Scene name 2 is null. Please enter a scene name.");
            return;
        }
    }

    void Start() {
        changeSceneScript = GetComponent<ChangeSceneScript>();
        Debug.Log("Checking for save data...");
        CheckSave();
    }

    private void CheckSave(){
        PlayerProfileData saveData;

        try {
            saveData = SaveSystem.LoadPlayerProfile();
        } catch (System.Exception) {
            Debug.Log("No save data found.");
            changeSceneScript.sceneName = fallbackSceneName;
            return;
        }

        if (saveData != null)
        {
            changeSceneScript.sceneName = defaultSceneName;
            Debug.Log("Welcome back, " + saveData.playerName + "!");
            return;
        }
    }
}
