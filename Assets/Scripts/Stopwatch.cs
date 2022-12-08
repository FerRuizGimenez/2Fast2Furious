using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    public GameObject streetManagerGO;
    public StreetManager streetManagerScript;
    public float myTime;
    public float myDistance;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI distanceTxt;
    public TextMeshProUGUI finalDistanceTxt;

    private void Start() 
    {
        streetManagerGO = GameObject.Find("StreetManager");
        streetManagerScript = streetManagerGO.GetComponent<StreetManager>();

        timeTxt.text = "2:00";
        distanceTxt.text = "0"; 

        myTime = 120.0f;
    }

    private void Update() 
    {
        if(streetManagerScript.gameStarted == true && streetManagerScript.gameEnded == false)
        {
            CalculateTimeAndDistance();  
        }  

        if(myTime <= 0 && streetManagerScript.gameEnded == false)
        {
            streetManagerScript.gameEnded = true;
            streetManagerScript.GameOverStates();
            finalDistanceTxt.text = ((int)myDistance).ToString() + " mts";
            timeTxt.text = "0:00";
        }
    }

    void CalculateTimeAndDistance()
    {
        myDistance += Time.deltaTime * streetManagerScript.speed;
        distanceTxt.text = ((int)myDistance).ToString(); 

        myTime -= Time.deltaTime;
        int minutes = (int)myTime/60;
        int seconds = (int)myTime%60;
        timeTxt.text = minutes.ToString() + ":" + seconds.ToString().PadLeft(2, '0');
    }
}
