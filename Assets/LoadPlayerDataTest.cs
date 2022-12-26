using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPlayerDataTest : MonoBehaviour
{
    public TMP_Text statusText;

    private void Start()
    {
        statusText.text = "Loading...";
        StartCoroutine(LoadPlayerData());
    }

    private IEnumerator LoadPlayerData()
    {
        PlayerProfileData playerProfileData = SaveSystem.LoadPlayerProfile();

        if(playerProfileData == null)
        {
            PlayerProfileData newPlayerProfileData = new PlayerProfileData();
            newPlayerProfileData.playerName = "New Player";
            newPlayerProfileData.playerLevel = 1;
            
            SaveSystem.SavePlayerProfile(new PlayerProfile(newPlayerProfileData));

            StartCoroutine(LoadPlayerData());
            yield break;
        }

        statusText.text = "Loaded!";
        yield return null;
    }
}
