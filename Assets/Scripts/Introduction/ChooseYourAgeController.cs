using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseYourAgeController : IntroductionPanel
{
    public TMP_InputField nameInputField;
    public Button acceptButton;

    int playerAge;

    void Start()
    {
        acceptButton.onClick.AddListener(() =>
        {
            FinishPanel(playerAge);
        });
    }

    void Update()
    {
        if (nameInputField.text.Length > 0)
            acceptButton.interactable = true;
        else
            acceptButton.interactable = false;


        if( nameInputField.text == playerAge.ToString())
            return;

        playerAge = int.Parse(nameInputField.text);
    }

    public int GetPlayerAge()
    {
        return playerAge;
    }
}
