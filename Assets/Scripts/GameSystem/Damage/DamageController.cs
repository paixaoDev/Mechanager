using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] Vector2 minMaxTimer;
    [SerializeField] List<DamageArea> damageAreas;
    [SerializeField] GameObject damagePrefab;

    float time;
    float randomTime;

    private DamageArea ChoiceArea (){
        return damageAreas[Random.Range(0, damageAreas.Count)];
    }

    void Start (){
        CreateDamegeRandomTimer();
    }

    void Update () {
            if(time < randomTime) {
                time += Time.deltaTime;
            }else{
                CreateDamage();
                CreateDamegeRandomTimer();
                time = 0;
            }
    }

    private void CreateDamegeRandomTimer (){
        randomTime = Random.Range(minMaxTimer.x, minMaxTimer.y);
    }

    public void CreateDamage () {
        Instantiate(damagePrefab, ChoiceArea().GetRandomVector(), transform.rotation);
    }

}
