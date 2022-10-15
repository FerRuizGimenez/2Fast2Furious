using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{
    public GameObject streetContainerGO;
    public GameObject[] streetContainerArray;
    public float speed;
    public bool gameStarted;
    public bool gameEnded;

    int streetCount = 0;
    int streetSelectorNumber;

    public GameObject previousStreet;
    public GameObject nextStreet;
    public float streetSize;

    private void Start() 
    {
        GameStarted();
    }

    private void Update() 
    {
        if(gameStarted == true && gameEnded == false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);    
        }
    }
    void GameStarted()
    {
        streetContainerGO = GameObject.Find("StreetContainer");
        MotorSpeed();
        SearchStreets();
    }

    void MotorSpeed()
    {
        speed = 18.0f;
    }

    void SearchStreets()
    {
        streetContainerArray = GameObject.FindGameObjectsWithTag("Street");    
        for(int i = 0; i < streetContainerArray.Length; i++)
        {
            streetContainerArray[i].gameObject.transform.parent = streetContainerGO.transform;
            streetContainerArray[i].gameObject.SetActive(false);
            streetContainerArray[i].gameObject.name = "StreetOff_"+i;    
        }

        CreateStreets();
    }

    void CreateStreets()
    {
        streetCount++;
        streetSelectorNumber = Random.Range(0, streetContainerArray.Length);
        GameObject street = Instantiate(streetContainerArray[streetSelectorNumber]);
        street.SetActive(true);
        street.name = "Street " + streetCount;
        street.transform.parent = gameObject.transform;
        PositioningStreets();
    }

    void PositioningStreets()
    {
        previousStreet = GameObject.Find("Street " + (streetCount -1));
        nextStreet = GameObject.Find("Street " + streetCount);
        MeasureStreet();
        nextStreet.transform.position = new Vector3(previousStreet.transform.position.x, 
            previousStreet.transform.position.y + streetSize, 0);
    }

    void MeasureStreet()
    {
        for(int i = 0; i < previousStreet.transform.childCount; i++)
        {
            if(previousStreet.transform.GetChild(i).GetComponent<Piece>() != null)
            {
                float pieceSize = previousStreet.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;  
                streetSize = streetSize + pieceSize; 
            }
     
        }      
    }
}
