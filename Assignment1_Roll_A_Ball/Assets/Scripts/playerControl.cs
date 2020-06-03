using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;
    private int count;
    public Text countText;
    public Text winText;
    private int _time = 10;
    GameObject[] gameObjects;
    GameObject[] gameObjects2;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

        //puts all objects with the tag into a list
        gameObjects = GameObject.FindGameObjectsWithTag("cyl"); 
        gameObjects2 = GameObject.FindGameObjectsWithTag("Pick Up");




    }
    private void Update()
    {
        if (count >= 23) //game ends when the score is 23 
        {
            winText.text = "You Win!";
            StartCoroutine(waitThreeSeconds());
            
        }

     
    }


    private void FixedUpdate() // called before any physics 
    {
        //grabs input from player - from keybaord 
        float moveHorizantal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 mouvment = new Vector3(moveHorizantal,0, moveVertical);

        _rb.AddForce(mouvment*speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up")) //checks for collision for a specific type of object and counts the score accordingly 
        {
            other.gameObject.SetActive(false); //setse objects to false so they go away after a collision 
            count += 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("cyl")) 
        {
            other.gameObject.SetActive(false);
            count += 3;
            SetCountText();
        }

    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString(); //updates the count 
        
    }
    IEnumerator waitThreeSeconds() //runs when game is over 
    {
        yield return new WaitForSeconds(3);  //waits 3 seconds 

            
        count = 0;
        SetCountText();
        winText.text = "";
        foreach (GameObject item in gameObjects)
            {
                item.SetActive(true); //reactivates all deactivated or collected objects 
            }
        foreach (GameObject thing in gameObjects2)
        {
            thing.SetActive(true); //reactivates all deactivated or collected objects 
        }

    }


}
