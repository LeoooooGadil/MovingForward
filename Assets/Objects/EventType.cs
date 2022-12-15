using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Calendar Event", menuName = "Moving Forward/Calendar/New Calendar Event", order = 2)]
public class EventType : ScriptableObject
{
    [SerializeField]
	new string name;
    
    [SerializeField]
    string _id;
}
