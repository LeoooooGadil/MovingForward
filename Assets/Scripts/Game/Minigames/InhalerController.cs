using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// this script is attached to the inhaler game object
// its job is to make the inhale exhale component work
public class InhalerController : MonoBehaviour
{
    public TMP_Text inhalerText;
    public Image[] inhalerOuterCircles = new Image[4];
    public float currentTimer = 0f;
    public float maxTimerWhenInhaling = 3f;
    public float maxTimerWhenExhaling = 3f;
    public bool isExhaling = false;
    public int inhaleCount = 0;
    
    // a certain rate in float that determins how much the outer circle should grow
    public float outerCircleGrowthRate = 0.1f;

    public Image inhalerPanel;
    public Button inhalerButton;

    public bool isStarted = false;

    void Start()
    {
        SetInhalerText("Inhaler");
        inhalerButton.onClick.AddListener(StartInhaler);
    }

    public void StartInhaler() {
        isStarted = true;
        inhalerPanel.gameObject.SetActive(false);
    }

    public void SetInhalerText(string text)
    {
        inhalerText.text = text;
    }

    public void makeOuterCircleBigger() {
        // make the outer circle bigger based on the index
        for (int i = 0; i < inhaleCount; i++) {
            inhalerOuterCircles[i].transform.localScale += new Vector3(outerCircleGrowthRate + i, outerCircleGrowthRate + i, 0f);
        }
    }

    public void makeOuterCircleSmaller() {
        // make the outer circle smaller based on the index
        for (int i = 0; i < inhaleCount; i++) {
            inhalerOuterCircles[i].transform.localScale -= new Vector3(outerCircleGrowthRate + i, outerCircleGrowthRate + i, 0f);
        }
    }

    void Update() {
        if (!isStarted) return;

        if (isExhaling) {
            currentTimer += Time.deltaTime;
            if (currentTimer >= maxTimerWhenExhaling) {
                isExhaling = false;
                currentTimer = 0f;
                SetInhalerText("Inhale");
                makeOuterCircleBigger();
            }
        } else {
            currentTimer += Time.deltaTime;
            if (currentTimer >= maxTimerWhenInhaling) {
                isExhaling = true;
                currentTimer = 0f;
                SetInhalerText("Exhale");
                inhaleCount++;
                makeOuterCircleSmaller();
            }
        }
    }
}
