using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class Comand : MonoBehaviour
{
    UnityEvent returnListener;

    public void InitComand(UnityEvent returnListener){
        this.returnListener = returnListener;
        StartComand();
    }

     public void InitComand(){
        StartComand();
    }

    internal virtual void StartComand ()
    {
        
    }

    internal virtual void FinishComand ()
    {
        this.returnListener?.Invoke();
    }
}
