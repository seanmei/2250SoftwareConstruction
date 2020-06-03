using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpL : MonoBehaviour
{
    public float min = 2f;
    public float max = 3f;
    // Use this for initialization
    void Start()
    {
        //sets the boundary 
        min = transform.position.x -7;
        max = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {

        //moves object back and forward from left to right
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2 -3, max - min) + min, transform.position.y, transform.position.z);

    }
}
