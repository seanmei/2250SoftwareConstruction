using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{

    public float radius = 2f;
    public bool keepOnScreen = true;

    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;

    public bool offRight, offLeft, offUp, offDown; 


    
    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect; 

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if (pos.x > camWidth - radius) {
            pos.x = camWidth - radius;
            isOnScreen = false;
            offRight = true;
        }

        if (pos.x < -camWidth + radius) {
            pos.x = -camWidth + radius;
            isOnScreen = false;
            offLeft = true;
        }

        if (pos.y > camWidth - radius + 10) {
            pos.y = camWidth - radius + 10;
            isOnScreen = false;
            offUp = true;
        }

        if (pos.y < -camWidth + radius - 10)
        {
            pos.y = -camWidth + radius - 10;
            isOnScreen = false;
            offDown = true;
        }
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;

        }
        isOnScreen = !(offRight || offLeft || offUp || offDown);
        if(keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }

        
    }

    private void OnDrawGizmos(){
        if (!Application.isPlaying)
        {
            Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
            Gizmos.DrawCube(Vector3.zero, boundSize);
        }
    }

}
