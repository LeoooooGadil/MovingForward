using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteboardDailyTaskButton : MonoBehaviour
{
    public string controllerName;

    public void OnClick()
    {
        GameObject.Find(controllerName).GetComponent<DailyTasksController>().ToggleMenu();
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
}
