using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermsAndConditionController : IntroductionPanel
{
	bool isTermsAndConditionAccepted = false;
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
		isTermsAndConditionAccepted = true;
		FinishPanel(true);
	}

	public void DeclineTermsAndCondition()
	{
		isTermsAndConditionAccepted = false;
	}
}
