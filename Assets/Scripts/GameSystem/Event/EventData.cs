using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "EventSystem/EventItem", order = 1)]
public class EventData : ScriptableObject 
{
    public Comand comand;
    public DialogData dialog;
}