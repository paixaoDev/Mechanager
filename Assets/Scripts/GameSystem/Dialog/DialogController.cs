using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private List<DialogData> dialogs;
    
    public void Start (){
        PresentNewDialog(dialogs[0]);
    }

    public void AddDialogToList (DialogData dialog){
        dialogs.Add(dialog);
    }

    public void RemoveDialogFromList (int index){

    }

    public void PresentNewDialog (DialogData dialog){
        //Intancio o objeto e coloco como filho deste objeto
        GameObject prefab = Instantiate(dialogPrefab, transform.position, transform.rotation);
        prefab.transform.parent = gameObject.transform;

        //Passo os valores para a UI
        DialogUIItem dialogUIItem = prefab.GetComponent<DialogUIItem>();
        dialogUIItem.UItext.text = dialog.message;
        dialogUIItem.UIimage.sprite = dialog.image;

        //Adiciono este prefab para o dialog (para controle futuro)
        dialog.dialogPrefab = prefab;
    }
}
