using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(ChangeSceneScript))]
public class SaveCheckerScript : MonoBehaviour
{
    public Object defaultSceneObject;
    public Object fallbackSceneObject;

    string sceneName_1;
    string sceneName_2;

    ChangeSceneScript changeSceneScript;


    void OnValidate()
    {
        if (defaultSceneObject == null)
        {
            Debug.LogError("Scene object 1 is null");
            return;
        }

        if (fallbackSceneObject == null)
        {
            Debug.LogError("Scene object 2 is null");
            return;
        }

        if (defaultSceneObject != null)
        {
            sceneName_1 = defaultSceneObject.name;
        }

        if (fallbackSceneObject != null)
        {
            sceneName_2 = fallbackSceneObject.name;
        }
    }

    void Start() {
        changeSceneScript = GetComponent<ChangeSceneScript>();
        CheckSave();
    }

    private void CheckSave(){
        PlayerProfileData saveData = SaveSystem.LoadPlayerProfile();

        if (saveData != null)
        {
            changeSceneScript.sceneObject = defaultSceneObject;
            Debug.Log("Welcome back, " + saveData.playerName + "!");
        }
        else
        {
            changeSceneScript.sceneObject = fallbackSceneObject;
        }
    }
}
