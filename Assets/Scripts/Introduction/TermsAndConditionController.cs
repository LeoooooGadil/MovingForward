using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermsAndConditionController : IntroductionPanel
{
	public Button acceptButton;

	void Start()
	{
        acceptButton = acceptButton.GetComponent<Button>();
        acceptButton.onClick.AddListener(() =>
        {
            AcceptTermsAndCondition();
        });
	}

	public void AcceptTermsAndCondition()
	{
		FinishPanel(true);
	}
}
