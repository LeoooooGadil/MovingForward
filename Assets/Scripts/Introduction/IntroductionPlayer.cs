using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionPlayer : IntroductionPanel
{
	public float waitTime = 10f;
	float timer = 0f;
	public bool isIntroFinished = false;

	void Start()
	{
		timer = waitTime;
	}

	void Update()
	{
		if (!isPanelFinished)
		{
			nextStep();
		}
	}

	void nextStep()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			isIntroFinished = true;
			isPanelFinished = true;
		}
	}
}
