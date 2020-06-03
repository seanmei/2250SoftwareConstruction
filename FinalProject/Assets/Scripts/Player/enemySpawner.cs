using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Instantiate(enemy, new Vector3(i * 10, 0.5f, j * 10), Quaternion.identity); //iteratively spawns pickups
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} 
