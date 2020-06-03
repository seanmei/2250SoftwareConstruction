using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float delay = 2f;
    public GameObject explosionEffect;
    float countdown;
    bool hasExploded = false;
    public float radius = 3f;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay; //how long does it take to detonate 
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }//detonate the gameobject
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] enemiesInRadius = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider enemy in enemiesInRadius)
        {
            Enemy trackHealth = enemy.transform.GetComponent<Enemy>(); //gets enemy 
            if (trackHealth != null)//checks if hit 
            {
                trackHealth.TakeDamage(50f); //removes enemy 
            }
        }
        Destroy(gameObject);
    }
}
