using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    

    float timeCounter = 0;
    public int offset;
    private void Start()
    {
        
    }
    void Update()
    {
        timeCounter -= Time.deltaTime; //tracks the change in time
        //creates a transform in each direction using trig functions for the circle and scales it
        float x = Mathf.Cos(timeCounter) * 5 ; 
        float y =  1;
        float z = Mathf.Sin(timeCounter)  *5 ;
        transform.position = new Vector3(x, y, z) ; //moves the object 
    }
}
