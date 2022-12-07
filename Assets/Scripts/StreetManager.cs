using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour
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
    public Vector3 screenLimitSize;
    public bool outOfScreen;

    public GameObject cameraGO;
    public Camera myCameraComponent;

    public GameObject carGO;
    public GameObject audioFXGO;
    public AudioFX audioFXScript;
    public GameObject bgFinalGO;

    private void Start() 
    {
        GameStarted();
    }

    private void Update() 
    {
        if(gameStarted == true && gameEnded == false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);  
            
            if(previousStreet.transform.position.y + streetSize < screenLimitSize.y && outOfScreen == false)
            {
                outOfScreen = true;  
                // Destroy street
                DestroyStreet();
            }  
        }

    }
    void GameStarted()
    {
        streetContainerGO = GameObject.Find("StreetContainer");
        cameraGO = GameObject.Find("Main Camera");
        myCameraComponent = cameraGO.GetComponent<Camera>();

        bgFinalGO = GameObject.Find("GameOverPanel");
        bgFinalGO.SetActive(false);

        audioFXGO = GameObject.Find("AudioFX");
        audioFXScript = audioFXGO.GetComponent<AudioFX>();

        carGO = GameObject.FindObjectOfType<Car>().gameObject;

        MotorSpeed();
        MeasureScreenSize();
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

        outOfScreen = false;
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

    void MeasureScreenSize()
    {
        screenLimitSize = new Vector3(0, myCameraComponent.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f, 0);
    } 

    void DestroyStreet()
    {
        Destroy(previousStreet);  
        streetSize = 0; 
        previousStreet = null;  
        CreateStreets();
    }

    public void GameOverStates()
    {
        carGO.GetComponent<AudioSource>().Stop();
        audioFXScript.FXMusic();
        bgFinalGO.SetActive(true);        
    }
}
