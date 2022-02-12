using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class Comand : MonoBehavior
{
    //evento de listener que executa quanto este comando finaliza
    UnityEvent returnListener;

    //Metodo Para iniciar comando
    public void InitComand(UnityEvent returnListener){
        this.returnListener = returnListener;
        StartComand();
    }

    //Metodo virtual utilizado por classe filha para customizar comando - inicio
    internal virtual void StartComand (){}

    //Metodo virtual utilizado por classe filha para customizar comando - fim
    internal virtual void FinishComand ()
    {
        this.returnListener?.Invoke();
    }
}
