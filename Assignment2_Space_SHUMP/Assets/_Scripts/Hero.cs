using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S;

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;


    private float _shieldLevel =1;  
    private GameObject lastTriggerGo = null;

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
        Destroy(other.gameObject);


    }


    public float shieldLevel
    {
        get{
            return (_shieldLevel);
        }
        set{
            _shieldLevel= Mathf.Min(value,4);
            if(value < 0)
            {
                Destroy(this.gameObject);
            }

        }     
    }

    private void Awake(){
        if(S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero,S");
        }
    }


    // Update is called once per frame
    void Update(){

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
        
    }
}

