using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWorldMenuSystem : MonoBehaviour
{
    public GameObject mainMenuButton;
    public GameObject mainMenuPanel;
    public GameObject mainMenuPanelBackground;

    public AudioClip menuOpenSound;
    public AudioClip menuCloseSound;

    bool isMenuOpen = false;

    void Awake()
    {
        mainMenuPanel.SetActive(false);
        mainMenuPanelBackground.SetActive(false);

        mainMenuButton.GetComponent<Button>().onClick.AddListener(ToggleMenu);
        mainMenuPanelBackground.GetComponent<Button>().onClick.AddListener(ToggleMenu);
    }

    void ToggleMenu()
	{
		if (isMenuOpen)
		{
            PlaySound(menuCloseSound);
			CloseMenu();
		}
		else
		{
            PlaySound(menuOpenSound);
			OpenMenu();
		}
	}

	private void PlaySound(AudioClip clip)
	{
		if (clip != null)
		{
			SoundManager.instance.PlaySFXOneShot(clip);
		}
	}

	public void OpenMenu()
    {
        mainMenuPanel.SetActive(true);
        mainMenuPanelBackground.SetActive(true);
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        mainMenuPanel.SetActive(false);
        mainMenuPanelBackground.SetActive(false);
        isMenuOpen = false;
    }
}
