using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    float damage = 10;
    float life = 100;

    void Start (){
        DoDamage();
    }

    public void DoDamage (){
        HeathController.instance.TakeDamage();
    }

    public void FixDamage(){
        life -= 10;
        Debug.Log("life: ${life}");
        if(life <= 0){
            Destroy(gameObject);
        
        }
    }

    void OnDestroy (){
        HeathController.instance.GetHeath(5f);
    }
}
