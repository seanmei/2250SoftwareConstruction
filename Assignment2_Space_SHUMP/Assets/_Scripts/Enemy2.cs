using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Enemy2 : MonoBehaviour
{
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;
    public int direction; 

    private BoundsCheck bndCheck;


    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    void Start()
    {
    }
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();

        System.Random rad = new System.Random();
        direction = rad.Next(0, 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    
        if (bndCheck != null && bndCheck.offLeft)
        {
            Destroy(gameObject);
        }
        if (bndCheck != null && bndCheck.offRight)
        {
            Destroy(gameObject);
        }



    }

    public virtual void Move()
    {


        if(direction ==1)
        {
            Vector3 tempPos = pos;
            tempPos.y -= speed * Time.deltaTime;
            tempPos.x -= speed * Time.deltaTime;
            pos = tempPos;
           
        }
        else
        {
            Vector3 tempPos = pos;
            tempPos.y -= speed * Time.deltaTime;
            tempPos.x += speed * Time.deltaTime;
            pos = tempPos;
        
        }

    }

}
