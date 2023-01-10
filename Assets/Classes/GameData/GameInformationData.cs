
using UnityEngine;
using System.Collections.Generic;
using static TimeCycleManager;

[System.Serializable]
public class GameInformationData
{   
    [SerializeField]
    public List<TimeCycleItem> timeCycleItems = new List<TimeCycleItem>();
    [SerializeField]
    public int currentScenery = 0;

    public GameInformationData()
    {
        timeCycleItems = null;
        currentScenery = 0;
    }

    public GameInformationData(GameInformation gameInformation)
    {
        timeCycleItems = gameInformation.getTimeCycleItems();
        currentScenery = gameInformation.getCurrentScenery();
    }
}
