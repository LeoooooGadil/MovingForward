using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseYourNameController : IntroductionPanel
{
    public TMP_InputField nameInputField;
    public GameObject successPanel;
    public Button acceptButton;
    TMP_Text successText;

    string playerName;

    void Start()
    {
        successText = successPanel.GetComponentInChildren<TMP_Text>();

        acceptButton.onClick.AddListener(() =>
        {
            successText.text = "Hello, " + playerName + "!";
            FinishPanel(playerName);
        });
    }

    void Update()
    {
        if (nameInputField.text.Length > 0)
            acceptButton.interactable = true;
        else
            acceptButton.interactable = false;


        if(nameInputField.text == playerName)
            return;

        playerName = nameInputField.text;
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}
