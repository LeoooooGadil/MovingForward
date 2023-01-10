using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleManager : MonoBehaviour
{
	public Image fadeImage;
	public GameObject formPanel;
	public GameObject introductionPanel;
	public GameObject listContent;
	public GameObject eventItemPrefab;
	public GameObject addEventButtonPrefab;
    public Button introductionDoneButton;
    public AudioClip buttonClickSound;

	[InspectorButton("resetCurrentSchedule")]
	public bool resetSchedule;

	public bool isPlayerNew = false;

	void Start()
	{
		formPanel.SetActive(false);
		introductionPanel.SetActive(false);

		PlayerProfileData playerProfileData = SaveSystem.LoadPlayerProfile();

		if (playerProfileData != null)
		{
			PlayerProfile playerProfile = new PlayerProfile(playerProfileData);
			isPlayerNew = !playerProfile.isPlayerAddedToCalendar;
		}
		else
		{
			isPlayerNew = true;
		}

		Debug.Log("isPlayerNew: " + isPlayerNew);

        introductionDoneButton.onClick.AddListener(async () => await introductionIsDone());

		if (isPlayerNew)
		{
			introductionPanel.SetActive(true);
		}
		else
		{
			formPanel.SetActive(true);
			UpdateList();
		}

		fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0);
	}

	public async Task introductionIsDone()
	{
		PlayerProfileData playerProfileData = SaveSystem.LoadPlayerProfile();

		if(playerProfileData != null) {
			playerProfileData.isPlayerAddedToCalendar = true;
			SaveSystem.SavePlayerProfile(new PlayerProfile(playerProfileData));
		}

        PlayOneShot(buttonClickSound);

		await FadeIn();
        introductionPanel.SetActive(false);
        formPanel.SetActive(true);
		UpdateList();
		await Wait(0.5f);
		await FadeOut();
	}

    public void PlayOneShot(AudioClip clip)
    {
        if(clip != null)
        {
            SoundManager.instance.PlaySFXOneShot(clip);
        }
    }

	void UpdateList()
	{
		// remove all children
		foreach (Transform child in listContent.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		PlayerSchedule playerSchedule = new PlayerSchedule();
		PlayerScheduleData playerScheduleData = SaveSystem.LoadPlayerSchedule();
		if (playerScheduleData != null)
		{
			playerSchedule = new PlayerSchedule(playerScheduleData);
		}

		for (int i = 0; i < playerSchedule.getEventCount(); i++)
		{
			PlayerScheduleEvent playerScheduleEvent = playerSchedule.getEvent(i);
			GameObject eventItem = Instantiate(eventItemPrefab, listContent.transform);
			eventItem.GetComponent<EventItemComponent>().eventName = playerScheduleEvent.eventName;
			eventItem.GetComponent<EventItemComponent>().eventWeekday = WeekdayConverter.ConvertWeekdayIntToString(playerScheduleEvent.eventWeekday);
			eventItem.GetComponent<EventItemComponent>().eventTimeStart = playerScheduleEvent.eventTimeStart;
			eventItem.GetComponent<EventItemComponent>().eventTimeEnd = playerScheduleEvent.eventTimeEnd;
			eventItem.GetComponent<EventItemComponent>().eventType = playerScheduleEvent.eventType;
		}

		GameObject addEventButton = Instantiate(addEventButtonPrefab, listContent.transform);
	}

	public void resetCurrentSchedule()
	{
		Debug.Log("Resetting schedule...");
		SaveSystem.resetSaveFile(SaveSystem.playerSchedulePath);
		UpdateList();
	}

	private async Task Wait(float seconds)
	{
		await Task.Delay((int)(seconds * 1000));
	}

	public async Task FadeIn()
	{
		fadeImage.raycastTarget = true;
		fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
		fadeImage.canvasRenderer.SetAlpha(0.0f);
		fadeImage.CrossFadeAlpha(1.0f, 0.3f, false);
		await Task.Delay(300);
	}

	public async Task FadeOut()
	{
		fadeImage.canvasRenderer.SetAlpha(1.0f);
		fadeImage.CrossFadeAlpha(0.0f, 0.5f, false);
		await Task.Delay(300);
		fadeImage.raycastTarget = false;
	}
}
