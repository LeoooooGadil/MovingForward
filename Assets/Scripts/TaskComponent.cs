using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskComponent : MonoBehaviour
{
	public TMP_Text taskText;
	public TMP_Text pointsText;
	public Button taskButton;
	Image taskImage;

	[HideInInspector]
	public string taskName;
	[HideInInspector]
	public int taskPoints;
	public bool taskIsCompleted;

	Image taskButtonImage;
	public Sprite taskButtonNormalSprite;
	public Sprite taskButtonDisabledSprite;
	public Sprite taskRadioButtonSprite;
	public Sprite taskRadioButtonDisabledSprite;
	public Sprite taskRadioButtonPressedSprite;
	public Sprite taskRadioButtonPressedDisabledSprite;
	public DailyTaskListController dailyTaskListController;

	void Start()
	{
		taskImage = GetComponent<Image>();
		taskText.text = taskName;
		pointsText.text = "+" + taskPoints.ToString() + "xp";
		taskButton.onClick.AddListener(CompleteTask);
		taskImage.sprite = taskButtonNormalSprite;
		taskButton.spriteState = new SpriteState()
		{
			highlightedSprite = taskRadioButtonSprite,
			pressedSprite = taskRadioButtonPressedSprite,
			selectedSprite = taskRadioButtonSprite,
			disabledSprite = taskRadioButtonSprite
		};

		if (taskIsCompleted)
		{
			taskButtonImage = taskButton.GetComponent<Image>();
			taskButtonImage.sprite = taskRadioButtonPressedSprite;
			taskButton.interactable = false;

			taskImage.sprite = taskButtonDisabledSprite;
			taskButton.spriteState = new SpriteState()
			{
				highlightedSprite = taskRadioButtonPressedSprite,
				pressedSprite = taskRadioButtonPressedDisabledSprite,
				selectedSprite = taskRadioButtonPressedSprite,
				disabledSprite = taskRadioButtonPressedSprite
			};
		}
	}

	void CompleteTask()
	{
		// complete the task
		// update the task button
		taskButtonImage = taskButton.GetComponent<Image>();
		taskButtonImage.sprite = taskRadioButtonPressedSprite;
		taskButton.interactable = false;

		taskImage.sprite = taskButtonDisabledSprite;
		taskButton.spriteState = new SpriteState()
		{
			highlightedSprite = taskRadioButtonPressedSprite,
			pressedSprite = taskRadioButtonPressedDisabledSprite,
			selectedSprite = taskRadioButtonPressedSprite,
			disabledSprite = taskRadioButtonPressedSprite
		};

		dailyTaskListController.CompleteTask(taskName);
	}
}
