using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[] fxs;
    AudioSource audioS;
    private void Start() 
    {
        audioS = GetComponent<AudioSource>();
    }

    public void FXCrashSound()
    {
        audioS.clip = fxs[0];
        audioS.Play();
    }  

    public void FXMusic()
    {
        audioS.clip = fxs[1];
        audioS.Play();
    }
}
