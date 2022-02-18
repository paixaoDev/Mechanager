using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

//Lista de eventos
public class EventController : MonoBehaviour
{
    [SerializeField] private List<EventData> events;

    public void Start (){
        foreach (EventData eventData in events)
        {
            gameObject.AddComponent(Type.GetType(eventData.comand.name));
            eventData.dialog = DialogController.instance.RequestNewDialog(eventData.dialog);
        }
    }

    public void ExecuteEvent (){
        var comand = gameObject.GetComponent(Type.GetType(events[0].comand.name)) as Comand;
        Debug.Log("Executa");
        comand.InitComand();
    }

    public void AddEvent (EventData eventData){
        eventData.dialog = DialogController.instance.RequestNewDialog(eventData.dialog);
        gameObject.AddComponent(Type.GetType(eventData.comand.name));
        events.Add(eventData);
    }

    public void RemoveEvent (EventData eventData){
        Destroy(eventData.dialog.dialogPrefab);
        events.Remove(eventData);
    }

    public void RemoveEvent(int index){
        Destroy(events[index].dialog.dialogPrefab);
        events.Remove(events[index]);
    }

    public void RemoveFirtEvent () {
        RemoveEvent(0);
    }
}
