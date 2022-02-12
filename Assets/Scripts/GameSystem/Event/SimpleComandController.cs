using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class SimpleComandController : Comand
{

    [SerializeField] bool autoStart = false;
    [SerializeField] bool restartComands = false;
    [SerializeField] List<Comand> comands;
    int actualComand = 0;
    
    internal override void StartComand()
    {
        base.StartComand();
        NextComand();
    }

    void Start()
    {
        if(autoStart)
            NextComand();
    }

    public void StartComands()
    {
        NextComand();
    }

    //Metodo recursivo por callback
    void NextComand (){
        //Crio novo evento e seto este metodo como listener (que ele ira iniciar)
        UnityEvent myEvent = new UnityEvent();
        myEvent.AddListener(NextComand);
        //aciono o comando da lista mandando o evento acima para ser executado quando comando da lista finalizar
        comands[actualComand].InitComand(myEvent);

        //Verifico o tamanho da lista e dependendo eu (reinicio a lista de eventos/ finalizo este evento e para com a recursividade)
        if(actualComand < comands.Count - 1){
            actualComand ++;
        }else{
            if(restartComands){
                actualComand = 0;
            }else{
                FinishComand();
            } 
        }
    }
}
