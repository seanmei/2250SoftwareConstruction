   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mouvement : MonoBehaviour
{

    public CharacterController controller; 
    public static float speed = 12f  ;
    public float gravity = -9.81f;
    public float jump = 3f; 

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    float lastX;
    float lastZ;
    float movementScoreAccum;

    static public bool speedUpgraded; //keeps track of speed upgrade status
    Text warningText;

    GameObject[] gameObjects;
    
    private void Start()
    {
        speed += PlayerPrefs.GetInt("speedInc");
        speedUpgraded = false;
        warningText = GameObject.Find("Warning").GetComponent<Text>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //checks if the player is on the ground 
        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;  //if on the ground and the velocity is downwards slow it down 
        }
            
        float x = Input.GetAxis("Horizontal");
        float  z= Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //moves 

        controller.Move(move * speed * Time.deltaTime); //speed 

        if(Input.GetButtonDown("Jump") && isGrounded) //jump if button pressed and on ground 
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);  //does math to figure out jump height 
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        if(lastX != x || lastZ != z)
        {
            movementScoreAccum += 1;
            if(movementScoreAccum >= 50) //score increases in discrete intervals from player travel
            {
                hero.score += 1;
                movementScoreAccum = 0;
            }
        }

        lastX = x;
        lastZ = z;
     }

    private void OnTriggerEnter(Collider other)
    {
        print("collided");
        if (other.gameObject.name == "Portal")
        {
            if (hero.score < hero.stage3)
            {
                warningText.text = ("You need at least 85 points to access next level");
            }
            else
            {
                SceneManager.LoadScene("secondLevel"); //starts the next scene
            }
        }
        else if (other.gameObject.name == ("AmmoPacket 1"))
        {
            Gun.bullets += 30;
            Destroy(other.gameObject);
        }
        else
        {
            hero.health -= 5; //removes 10 health per hit when colliding with enemies
        }
    }
}
     