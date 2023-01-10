using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneryButton : MonoBehaviour
{
	TMP_Text sceneryName;
	Button button;
	Image image;
	public Sprite buttonEnabledSprite;
	public Sprite buttonDisabledSprite;
	public Sprite buttonCurrentSprite;
	public SceneryController sceneryController;
	public string sceneryNameString;
	public int sceneryIndex;
	public bool isCurrentScenery = false;
	public bool isLocked = false;

	void Start()
	{
		sceneryName = GetComponentInChildren<TMP_Text>();
		sceneryName.text = sceneryNameString;

		button = GetComponent<Button>();
		image = GetComponent<Image>();
		button.onClick.AddListener(async () => await sceneryController.setScenery(sceneryIndex));

		if (isCurrentScenery)
		{
			button.image.sprite = buttonDisabledSprite;
			button.interactable = false;
		}
		else if (isLocked)
		{
			button.image.sprite = buttonDisabledSprite;
			button.interactable = false;
		}
		else
		{
			button.image.sprite = buttonCurrentSprite;
			button.interactable = true;
		}

	}
}
