using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este componente apenas EXIBE os dialogos
public class DialogController : MonoBehaviour
{
    public static DialogController instance;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private Transform dialogsParent;
    [SerializeField] private List<DialogData> dialogs;

    public void Awake(){
        if(instance == null) {
            instance = this;
        }else{
            Destroy(this);
        }
    }

    public DialogData RequestNewDialog (DialogData dialog){
        //Intancio o objeto e coloco como filho deste objeto
        GameObject prefab = Instantiate(dialogPrefab, transform.position, transform.rotation);
        prefab.transform.parent = dialogsParent;

        if(dialog.show){
            //Passo os valores para a UI
            DialogUIItem dialogUIItem = prefab.GetComponent<DialogUIItem>();
            dialogUIItem.UItext.text = dialog.message;
            dialogUIItem.UIimage.sprite = dialog.image;
        }else{
            prefab.SetActive(false);
        }

        //Adiciono este prefab para o dialog (para controle futuro)
        dialog.dialogPrefab = prefab;

        //TODO - Executar som do dialog
        return dialog;
    }
}
