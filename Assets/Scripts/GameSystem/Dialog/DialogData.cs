using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialogs/DialogItem", order = 1)]
public class DialogData : ScriptableObject
{
    [Tooltip("Pode usar tags HTML Doc: http://digitalnativestudios.com/textmeshpro/docs/rich-text/")]
    public string message;
    [Tooltip("Tem que ser um item do tipo sprite")]
    public Sprite image;
    [Tooltip("Se nulo ira pegar som padrao")]
    public AudioClip sfx;
    [Tooltip("Se for 500 ira exibir a frente de todos os outros dialogos, acima de 500 sera exibido na tela toda")]
    public int priority;

    [HideInInspector] public GameObject dialogPrefab;
}
