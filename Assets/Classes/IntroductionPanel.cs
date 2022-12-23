using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionPanel : MonoBehaviour
{
    public bool isPanelFinished = false;
    // a variable containing the data passed
    public object data = null;

    public void FinishPanel()
    {
        isPanelFinished = true;
    }

    public void FinishPanel(object data)
    {
        this.data = data;
        FinishPanel();
    }
}
