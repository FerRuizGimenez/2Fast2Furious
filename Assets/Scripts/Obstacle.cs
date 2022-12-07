using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obstacle : MonoBehaviour
{
    public GameObject stopwatchGO;
    public Stopwatch stopwatchScript;

    public GameObject audioFX;
    public AudioFX audioFXScript;

    private void Start() 
    {
        stopwatchGO = GameObject.FindObjectOfType<Stopwatch>().gameObject; 
        stopwatchScript = stopwatchGO.GetComponent<Stopwatch>();

        audioFX = GameObject.FindObjectOfType<AudioFX>().gameObject;
        audioFXScript = audioFX.GetComponent<AudioFX>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.GetComponent<Car>() != null)
        {
            audioFXScript.FXCrashSound();
            stopwatchScript.myTime = stopwatchScript.myTime - 20;
            Destroy(this.gameObject);
        }
    }   
}
