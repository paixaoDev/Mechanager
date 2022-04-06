using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioListener listener;
    [SerializeField] AudioSource fx;
    [SerializeField] AudioSource music;
    static public AudioController instance;

    void Awake (){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    public void Play (AudioClip audio){
        fx.clip = audio;
        fx.Play();
    }

    public void PlayMusic (AudioClip audio){
        music.clip = audio;
        music.Play();
    }

    public void PlaySfx (AudioClip audio){
        fx.clip = audio;
        fx.Play();
    }
}
