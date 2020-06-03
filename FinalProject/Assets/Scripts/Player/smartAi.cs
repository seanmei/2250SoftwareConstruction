using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class smartAi : MonoBehaviour
{

    Transform playerTransform;
    NavMeshAgent myNavmesh;
    public float checkRate = 0.01f;
    float nextCheck;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy) //checks for player GameOject 
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myNavmesh = gameObject.GetComponent<NavMeshAgent>(); //initiate navMesh 

    }
    private void Update()
    {
        if (Time.time > nextCheck) //tells enemy to check for player 
        {
            nextCheck = Time.time + checkRate;
            FollowPlayer();
        }


    }

    private void FollowPlayer()
    {
        myNavmesh.transform.LookAt(playerTransform); //looks for location of player //CANT USE THIS LINE OR YOU CAN COLLIDE
        myNavmesh.destination = playerTransform.position; //sets destination to player location 
    }
}
