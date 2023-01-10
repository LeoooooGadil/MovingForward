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
    public Transform[] inhalerOuterCircles = new Transform[4];
    public float currentTimer = 0f;
    public float maxTimerWhenInhaling = 3f;
    public float maxTimerWhenExhaling = 3f;
    public float maxTimerWhenWaiting = 3f;
    public bool isExhaling = false;
    public int inhaleCount = 0;
    public int exhaleCount = 0;
    public int howmanyTimesToBreath = 3;

    public Image inhalerPanel;
    public Button inhalerButton;

    // 0 = nothing
    // 1 = inhale
    // 2 = wait
    // 3 = exhale
    // 4 = wait
    public int state = 0;

    void Start()
    {
        SetInhalerText("Inhale");
        inhalerButton.onClick.AddListener(StartInhaler);
        makeOuterCircleAlpha();
    }

    public void StartInhaler() {
        inhalerPanel.gameObject.SetActive(false);
        state = 1;
    }

    public void SetInhalerText(string text)
    {
        inhalerText.text = text;
    }

    public void makeOuterCircleAlpha() {
        // make the outer circle alpha based on the index
        // make the scale of the circle smaller based on the maxTimerWhenExhaling and the percentage of 3

        float maxAlpha = 1f;
        float denominator = maxAlpha / inhalerOuterCircles.Length;

        for (int i = 0; i < inhalerOuterCircles.Length; i++) {
            Color color = inhalerOuterCircles[i].GetComponent<Image>().color;
            color.a = maxAlpha - (denominator * i);
            inhalerOuterCircles[i].GetComponent<Image>().color = color;
        }
    }

    public void makeOuterCircleBigger() {
        // make the outer circle bigger based on the index
        // make the scale of the circle bigger based on the maxTimerWhenInhaling and the percentage of 3
        float outerCircleGrowthRate = 0.01f / maxTimerWhenInhaling;
        // a float which determines how fast each circle grows


        // for each circle, make it bigger at a different rate


        for (int i = 0; i < inhalerOuterCircles.Length; i++) {
            float percentage = (i + 1) / (float)inhalerOuterCircles.Length;
            inhalerOuterCircles[i].localScale += new Vector3(outerCircleGrowthRate * percentage, outerCircleGrowthRate * percentage, 0f);
        }
    }

    public void makeOuterCircleSmaller() {
        // make the outer circle smaller based on the index
        // make the scale of the circle smaller based on the maxTimerWhenExhaling and the percentage of 3

        float outerCircleGrowthRate = 0.01f / maxTimerWhenExhaling;    
        for (int i = 0; i < inhalerOuterCircles.Length; i++) {
            float percentage = (i + 1) / (float)inhalerOuterCircles.Length;

            if(inhalerOuterCircles[i].localScale.x <= 0f) continue;

            inhalerOuterCircles[i].localScale -= new Vector3(outerCircleGrowthRate * percentage, outerCircleGrowthRate * percentage, 0f);
        }
    }

    void Update() {
        if(exhaleCount >= howmanyTimesToBreath && inhaleCount >= howmanyTimesToBreath) {
            // end the game
            // show the end panel
            // show the score
            // show the button to go back to the main menu

            state = 0;
            inhalerPanel.gameObject.SetActive(true);
            return;
        }

        switch(state) {
            case 0:
                // nothing
                break;
            case 1:
                // inhale
                currentTimer += Time.deltaTime;
                makeOuterCircleBigger();
                if (currentTimer >= maxTimerWhenInhaling) {
                    state = 2;
                    currentTimer = 0f;
                    SetInhalerText("Hold");
                    inhaleCount++;
                }
                break;
            case 2:
                // wait
                currentTimer += Time.deltaTime;
                // makeOuterCircleSmaller();
                if (currentTimer >= maxTimerWhenWaiting) {
                    state = 3;
                    currentTimer = 0f;
                    SetInhalerText("Exhale");
                }
                break;
            case 3:
                // exhale
                currentTimer += Time.deltaTime;
                makeOuterCircleSmaller();
                if (currentTimer >= maxTimerWhenExhaling) {
                    state = 4;
                    currentTimer = 0f;
                    SetInhalerText("Hold");
                    exhaleCount++;
                }
                break;
            case 4:
                // wait
                currentTimer += Time.deltaTime;
                // makeOuterCircleSmaller();
                if (currentTimer >= maxTimerWhenWaiting) {
                    state = 1;
                    currentTimer = 0f;
                    SetInhalerText("Inhale");
                }
                break;

        }
    }
}
