using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckUpR : MonoBehaviour
{
    // Start is called before the first frame update
    public float min = 2f;
    public float max = 3f;
    // Use this for initialization
    void Start()
    {
        //sets the boundary
        min = transform.position.x-1;
        max = transform.position.x+6; 

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.PingPong(Time.time * 2 -1, max - min) + min, transform.position.y, transform.position.z); //moves object back and forward from left to right

    }
}
