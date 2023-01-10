using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InhalerGame : MonoBehaviour
{

	// WHEN INHALING COUNT UP THE TIMER UNTIL THE MAX TIMER AND USE THE TIMER TO EXHALE AND MAKE THE CIRCLE SMALLER

	public TMP_Text centerText;
	public TMP_Text upperText;
	public TMP_Text testText;
	public Transform[] outerCircles = new Transform[4];
	float currentTimer = 0f;
	public float maxTimerWhenInhaling = 7f;
	public float timerWhenInhaling = 0f;
	public float maxTimerWhenExhaling = 7f;
	public float timerWhenExhaling = 0f;
	public int howManyTimesToBreath = 10;
	public int howLongToHold = 0;

	int inhaleCount = 0;
	int exhaleCount = 0;

	public string[] compliments = new string[6]{
		"Wow!",
		"Keep it up!",
		"You're doing great!",
		"Awesome!",
		"Nice!",
		"Breathetaking!"
	};


	// 0 = nothing
	// 1 = countdown to inhale
	// 2 = inhale
	// 3 = hold
	// 4 = exhale
	int state = 0;
	string previousCompliment = "";

	void Start()
	{
		SetCenterText("Ready");
		SetUpperText("Place your two thumbs on the screen to begin");
		outerCircleFade();
	}

	async void Update()
	{
		checkFingers();

		testText.text = Input.touchCount.ToString() + " " + state.ToString();

		switch (state)
		{
			case 0:
				currentTimer = 0f;
				if (inhaleCount == 0 && exhaleCount == 0)
				{
					SetCenterText("Ready");
					SetUpperText("Place your two thumbs on the screen to begin");
				}
				else if (howManyTimesToBreath <= 0)
				{
					SetCenterText("Done");
					SetUpperText("You have completed " + exhaleCount + " cycle(s). Well done!");

					//wait 3 seconds and then go back to the main menu
					if (currentTimer >= 3f)
					{
						await LevelManager.instance.LoadLastScene();
					}
				}
				else
				{
					SetCenterText("Again");
					SetUpperText("You have completed " + exhaleCount + " cycle(s). " + howManyTimesToBreath + " more to go");
				}
				break;
			case 1:
				countdownToInhale();
				break;
			case 2:
				Inhaling();
				break;
			case 3:
				HoldingToExhale();
				break;
			case 4:
				Exhaling();
				break;
			case 5:
				break;
			default:
				break;
		}

		currentTimer += Time.deltaTime;
	}

	// a coroutine that counts down from 3 to 0
	// when it reaches 0, it changes the state to 2
	// and changes the text to inhale
	void countdownToInhale()
	{

		if (inhaleCount != 0 || exhaleCount != 0)
		{
			state = 2;
			return;
		}

		SetUpperText("Get ready to inhale");
		// countdown from 3 to 0
		// wait 1 second count down



		if (currentTimer >= 3f)
		{
			currentTimer = 0f;
			state = 2;
			SetCenterText("Inhale");
		}
		else
		{
			SetCenterText((3 - currentTimer).ToString("F0"));
		}
	}

	void Inhaling()
	{
		SetUpperText("Inhaling for " + (maxTimerWhenInhaling - currentTimer).ToString("F1") + " seconds.\nRelease anytime to exhale.");
		SetCenterText("Inhale");
		makeOuterCircleBigger();
		if (currentTimer >= maxTimerWhenInhaling)
		{
			currentTimer = 0f;
			state = 3;
			inhaleCount++;
			SetCenterText("Hold");
			return;
		}

		timerWhenInhaling = currentTimer;
	}

	void Exhaling()
	{
		SetUpperText("Exhaling for " + (timerWhenInhaling - currentTimer).ToString("F1") + " seconds");
		SetCenterText("Exhale");
		makeOuterCircleSmaller();
		if (currentTimer >= timerWhenInhaling)
		{
			currentTimer = 0f;
			state = 0;
			howManyTimesToBreath--;
			howLongToHold = 0;
			exhaleCount++;
			PlayerStatisticsManager.instance.weeklyStatsManager.AddBreathingExerciseCompleted();
			return;
		}

		timerWhenExhaling = currentTimer;
	}

	// count how long the player holds their breath
	void HoldingToExhale()
	{
		SetUpperText("Holding for " + howLongToHold + " seconds.\nRelease your finger(s) to exhale.");


		if (currentTimer >= 1f)
		{
			currentTimer = 0f;
			howLongToHold++;

			// for every 10 seconds the player holds their breath, give them a compliment
			if (howLongToHold % 10 == 0)
			{
				// pick a random compliment from the array
				// check if the compliment is the same as the previous one
				// if it is, pick another one
				// if it isn't, set the compliment
				int randomCompliment = Random.Range(0, compliments.Length);
				if (compliments[randomCompliment] == previousCompliment)
				{
					while (compliments[randomCompliment] == previousCompliment)
					{
						randomCompliment = Random.Range(0, compliments.Length);
					}
				}
				else
				{
					previousCompliment = compliments[randomCompliment];
					SetCenterText(compliments[randomCompliment]);
				}

				SoundManager.instance.PlaySFX(4);
			}
		}
	}

	void SetCenterText(string text)
	{
		centerText.text = text;
	}

	void SetUpperText(string text)
	{
		upperText.text = text;
	}

	void outerCircleFade()
	{
		float maxAlpha = 1f;
		float denominator = maxAlpha / outerCircles.Length;

		for (int i = 0; i < outerCircles.Length; i++)
		{
			Color color = outerCircles[i].GetComponent<Image>().color;
			color.a = maxAlpha - (denominator * i);
			outerCircles[i].GetComponent<Image>().color = color;
		}
	}

	// check how many fingers are on the screen
	// if fingers is 2 and state is 0, change state to 1
	// if fingers is 1 and state is 1, change state to 0
	// if fingers is 0 and state is 1, change state to 0
	// if fingers is 1 and state is 3, change state to 
	// if fingers is 0 and state is 3, change state to 4
	// if fingers is 0 and state is 2, change state to 4
	// and reset the timer when the state changes
	void checkFingers()
	{
		if (Input.touchCount == 2 && state == 0)
		{
			state = 1;
			currentTimer = 0f;
		}
		else if (Input.touchCount == 1 && state == 1)
		{
			state = 0;
			currentTimer = 0f;
		}
		else if (Input.touchCount == 0 && state == 1)
		{
			state = 0;
			currentTimer = 0f;
		}
		else if (Input.touchCount == 1 && state == 3)
		{
			state = 4;
			currentTimer = 0f;
		}
		else if (Input.touchCount == 0 && state == 3)
		{
			state = 4;
			currentTimer = 0f;
		}
		else if (Input.touchCount == 0 && state == 2)
		{
			state = 4;
			currentTimer = 0f;
		}
	}

	public void makeOuterCircleBigger()
	{
		// make the outer circle bigger based on the index
		// make the scale of the circle bigger based on the maxTimerWhenInhaling and the percentage of 3
		float outerCircleGrowthRate = 0.015f / maxTimerWhenInhaling;
		// a float which determines how fast each circle grows


		// for each circle, make it bigger at a different rate


		for (int i = 0; i < outerCircles.Length; i++)
		{
			float percentage = (i + 1) / (float)outerCircles.Length;
			outerCircles[i].localScale += new Vector3(outerCircleGrowthRate * percentage, outerCircleGrowthRate * percentage, 0f);
		}
	}

	public void makeOuterCircleSmaller()
	{
		// make the outer circle smaller based on the index
		// make the scale of the circle smaller based on the maxTimerWhenExhaling and the percentage of 3

		float outerCircleGrowthRate = 0.015f / maxTimerWhenExhaling;
		for (int i = 0; i < outerCircles.Length; i++)
		{
			float percentage = (i + 1) / (float)outerCircles.Length;

			if (outerCircles[i].localScale.x <= 1f) continue;

			outerCircles[i].localScale -= new Vector3(outerCircleGrowthRate * percentage, outerCircleGrowthRate * percentage, 0f);
		}
	}
}
