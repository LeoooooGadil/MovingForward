
using System.Collections.Generic;
using static TimeCycleManager;

public class GameInformation
{
    public List<TimeCycleItem> timeCycleItems = new List<TimeCycleItem>();
    public int currentSceneryIndex;

    public GameInformation()
    {
        timeCycleItems = null;
        currentSceneryIndex = 0;
    }

    public GameInformation(GameInformationData gameInformationData)
    {
        timeCycleItems = gameInformationData.timeCycleItems;
        currentSceneryIndex = gameInformationData.currentScenery;
    }

    public void setTimeCycleItems(List<TimeCycleItem> timeCycleItems)
    {
        this.timeCycleItems = timeCycleItems;
    }

    public List<TimeCycleItem> getTimeCycleItems()
    {
        return timeCycleItems;
    }

    public void setCurrentScenery(int currentSceneryIndex)
    {
        this.currentSceneryIndex = currentSceneryIndex;
    }

    public int getCurrentScenery()
    {
        return currentSceneryIndex;
    }
}
