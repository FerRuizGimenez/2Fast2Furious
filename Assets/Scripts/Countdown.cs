using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public GameObject streetManagerGO;
    public StreetManager streetManagerScript;
    public Sprite[] numbers;
    public GameObject numberCounterGO;
    public SpriteRenderer numberCounterSprt;
    public GameObject carControllerGO;
    public GameObject carGO;

    private void Start() 
    {
        ComponentStart();   
    }

    void ComponentStart()
    {
        streetManagerGO = GameObject.Find("StreetManager");
        streetManagerScript = streetManagerGO.GetComponent<StreetManager>();
        numberCounterGO = GameObject.Find("NumberCounter");
        numberCounterSprt = numberCounterGO.GetComponent<SpriteRenderer>();
        carGO = GameObject.Find("Car");
        carControllerGO = GameObject.Find("CarController");  

        StartCountdown(); 
    }

    void StartCountdown()
    {
        StartCoroutine(Counting());
    }

    IEnumerator Counting()
    {
        carControllerGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        numberCounterSprt.sprite = numbers[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        numberCounterSprt.sprite = numbers[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        numberCounterSprt.sprite = numbers[3];
        streetManagerScript.gameStarted = true;
        numberCounterGO.GetComponent<AudioSource>().Play();
        carGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        numberCounterGO.SetActive(false);
    }
}
