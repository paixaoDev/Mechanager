using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyReceiver : MonoBehaviour
{
    [SerializeField] float energy = 100;
    [SerializeField] float timeToLose = 5f;
    [SerializeField] float minEnergyToWork = 100;
    [SerializeField] float maxEnergy = 1000;
    [SerializeField] EnergyContainer energyContainer;

    float time = 0;
    bool caledForEnergy = false;

    public void SetEnergyContainer (EnergyContainer _energyContainer){
        this.energyContainer = _energyContainer;
    }

    void Update (){
        if(energy > 0){
            caledForEnergy = false;
            if(time < timeToLose) {
                time += Time.deltaTime;
            }else{
                energy -= 1;
                time = 0;
            }
        }else{
            if(!caledForEnergy){
                CallForEnergy ();
            }   
        }
    }

    public void CallForEnergy (){
        caledForEnergy = true;
        EnergyController.instance.CanGiveBatery();
        
    }

    public void AtachEnergy (){
        float _energy = 0f;
        if(energyContainer != null){
            _energy = energyContainer.GetEnergy();
            energyContainer.StopFollow(transform);

            if(_energy > 0){
                energy += _energy;
                HeathController.instance.GetHeath(10f);
            }else{
                energyContainer = null;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "EnergContainer"){
            SetEnergyContainer (col.gameObject.GetComponent<EnergyContainer>());
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "EnergContainer"){
            energyContainer = null;
        }
    }
}
