using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "EventSystem/EventItem", order = 1)]
public class EventData : ScriptableObject 
{
    public Object comand;
    public DialogData dialog;
}