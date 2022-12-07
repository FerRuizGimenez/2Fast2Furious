using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject carGO;
    public float rotation;
    public float speed;


    private void Start() 
    {
        carGO = GameObject.FindObjectOfType<Car>().gameObject;      
    }    
    
    private void Update() 
    {
        float zRotation = 0;

        transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);  

        zRotation = Input.GetAxisRaw("Horizontal") * -rotation;

        carGO.transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }
}
