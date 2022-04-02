using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    float x1;
    float y1;
    float x2;
    float y2;

    void Awake (){ 
        x1 = transform.position.x - (transform.lossyScale.x / 2);
        x2 = transform.position.x + (transform.lossyScale.x / 2);
        y1 = transform.position.y - (transform.lossyScale.y / 2);
        y2 = transform.position.y + (transform.lossyScale.y / 2);
    }

    public Vector2 GetRandomVector (){
        return new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
    }

}
