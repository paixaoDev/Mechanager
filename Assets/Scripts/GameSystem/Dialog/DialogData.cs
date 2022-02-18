using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialogs/DialogItem", order = 1)]
public class DialogData : ScriptableObject
{
    public string message;
    public Sprite image;
    public AudioClip sfx;
    public bool show = true;
    
    [HideInInspector] public GameObject dialogPrefab;
}
