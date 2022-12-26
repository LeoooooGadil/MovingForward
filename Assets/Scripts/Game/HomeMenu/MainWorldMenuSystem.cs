using UnityEngine;
using UnityEngine.UI;

public class MainWorldMenuSystem : MonoBehaviour
{
	public GameObject mainMenuButton;
	public GameObject mainMenuPanel;
	public GameObject mainMenuPanelBackground;
	public SceneryController sceneryController;

	bool isMenuOpen = false;

	void Awake()
	{
		mainMenuPanel.SetActive(false);
		mainMenuPanelBackground.SetActive(false);
	}

	void Start()
	{
		mainMenuButton.GetComponent<Button>().onClick.AddListener(ToggleMenu);
		mainMenuPanelBackground.GetComponent<Button>().onClick.AddListener(ToggleMenu);
		sceneryController.mainWorldMenuSystem = this;
	}

	void ToggleMenu()
	{
		if (isMenuOpen)
			CloseMenu();
		else
			OpenMenu();
			sceneryController.UpdateList();
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
