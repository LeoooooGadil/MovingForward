using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;

    public Object optionsMenu;
    public Object gameScene;
    public Object newGameScene;
    public bool newGame = false;

    void Start() {
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
    }

    private async void StartGame() {
        Debug.Log("Starting game...");
        if (newGame) {
            await LevelManager.instance.LoadScene("Introduction");
        } else {
            await LevelManager.instance.LoadScene("InGame");
        }
    }

    private async void OpenOptions() {
        Debug.Log("Opening options...");
        await LevelManager.instance.LoadScene(optionsMenu.name);
    }
}
