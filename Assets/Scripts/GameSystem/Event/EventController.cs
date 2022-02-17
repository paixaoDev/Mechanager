using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

//Lista de eventos
public class EventController : MonoBehaviour
{
    [SerializeField] private List<EventData> events;

    public void Start (){
        foreach (EventData eventData in events)
        {
            eventData.dialog = DialogController.instance.RequestNewDialog(eventData.dialog);
        }
    }

    public void ExecuteEvent (){
        UnityEvent myEvent = new UnityEvent();
        myEvent.AddListener(RemoveFirtEvent);
        events[0].comand.InitComand(myEvent);
    }

    public void AddEvent (EventData eventData){
        eventData.dialog = DialogController.instance.RequestNewDialog(eventData.dialog);
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
