using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelIndicator : MonoBehaviour
{
    TMP_Text text;
    
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string level = PlayerStatisticsManager.instance.xpManager.currentLevel.ToString();

        if(text.text == level)
            return;

        text.text = PlayerStatisticsManager.instance.xpManager.currentLevel.ToString();
    }
}
