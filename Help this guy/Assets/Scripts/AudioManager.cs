using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;
    public AudioSource bgm, levelEndMusic;

    private void Awake(){
        instance = this;
    }

    public void PlaySFX(int soundToPlay){
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        soundEffects[soundToPlay].Play();
    }
}
