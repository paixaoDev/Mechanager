using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "EventSystem/EventItem", order = 1)]
public class EventData : ScriptableObject {
    [Tooltip("Classe que estende de comand e ira ser executada")]
    public Comand eventToExecute;
}