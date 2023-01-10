using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyTasksController : MonoBehaviour
{
	public Button dailyTaskButton;
	public GameObject dailyTaskPanel;
	public GameObject dailyTaskPanelBackground;

	DailyTaskListController dailyTaskListController;

	bool isMenuOpen = false;

	void Awake()
	{
		dailyTaskPanel.SetActive(false);
		dailyTaskPanelBackground.SetActive(false);
	}

	void Start()
	{
		dailyTaskButton.onClick.AddListener(ToggleMenu);
		dailyTaskPanelBackground.GetComponent<Button>().onClick.AddListener(ToggleMenu);
		dailyTaskListController = GetComponent<DailyTaskListController>();
		dailyTaskListController.dailyTasksController = this;
	}

	public void ToggleMenu()
	{
		if (isMenuOpen)
			CloseMenu();
		else
			OpenMenu();
			dailyTaskListController.updateDailyTaskList();

	}

    public void OpenMenu()
    {
        dailyTaskPanel.SetActive(true);
        dailyTaskPanelBackground.SetActive(true);
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        dailyTaskPanel.SetActive(false);
        dailyTaskPanelBackground.SetActive(false);
        isMenuOpen = false;
    }
}
