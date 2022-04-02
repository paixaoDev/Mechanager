using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    static public EnergyController instance;
    [SerializeField] GameObject energyContainerPrefab;
    [SerializeField] bool canGiveBatery  = false;
    Transform player;

    void Awake (){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    public void CanGiveBatery (){
        canGiveBatery = true;
    }

    public void GiveBatery (){
        if(canGiveBatery){
            EnergyContainer energyContainer = Instantiate(energyContainerPrefab, transform.position, transform.rotation).GetComponent<EnergyContainer>();
            energyContainer.StartFollow(player);
            canGiveBatery = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            player = col.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            player = null;
        }
    }
}
