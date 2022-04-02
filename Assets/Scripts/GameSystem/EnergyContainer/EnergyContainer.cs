using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyContainer : MonoBehaviour
{
    [SerializeField] float energy = 100f;
    [SerializeField] float dischargeTime = 50f;
    [SerializeField] Transform energyPivot;

    [SerializeField] Transform objectToFollow;
    [SerializeField] bool follow = false;

    float scaleMax = 0f;

    void Start (){
        scaleMax = energyPivot.localScale.y;
        energyPivot.localScale = new Vector3(1, scaleMax * energy/100, 1);
    }

    void Update () {
        if(objectToFollow != null && follow){
            transform.position = Vector3.Lerp (transform.position, objectToFollow.position, 5 * Time.deltaTime);
        }
    }

    public void StartFollow (Transform target){
        objectToFollow = target;
        follow = true;
    }

    public void StopFollow (Transform target){
        follow = false;
        transform.position = target.position;
    }

    public void TestEnergyContainer (){
        GetEnergy();
    }

    public float GetEnergy (){
        float _energy = this.energy;
        if(this.energy > 0){
            this.energy = 0f;
            StartCoroutine(EnergyLost(dischargeTime, _energy));
        }
        return _energy;
    }

    IEnumerator EnergyLost (float vel , float ener){
        float en = ener;
        
        while (en > this.energy){
            energyPivot.localScale = new Vector3(1, scaleMax * en/100, 1);
            en -= vel * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
