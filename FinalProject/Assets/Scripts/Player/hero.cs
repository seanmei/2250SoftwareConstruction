using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hero : MonoBehaviour
{
    static public hero Player;

    public GameObject fireball;
    private GameObject playerBody;

    public Material green;
    public Material blue;
    public Material yellow;
    public Material magenta;

    static public int health;
    static public int score;
    Text scoreText;
    Text unlockText;
    GameObject bar;
    Text ammoText;

    public static int stage1 = 30;
    public static int stage2 = 50;
    public static int stage3 = 85;
    void Awake()
    {
        if (Player == null)
        {
            Player = this;
        } else
        {
            Debug.LogError("There singleton S of Hero already exist");
        }//singleton structure for initiating a player
    }

    private void Start()
    {
        playerBody = GameObject.Find("Capsule");
        string targetColour = PlayerPrefs.GetString("colour"); //retrieves desired colour
        switch (targetColour)
        {
            case "yellow": //finds and sets colour to current player model
                playerBody.GetComponent<Renderer>().material = yellow;
                break;
            case "green":
                playerBody.GetComponent<Renderer>().material = green;
                break;
            case "blue":
                playerBody.GetComponent<Renderer>().material = blue;
                break;
            case "magenta":
                playerBody.GetComponent<Renderer>().material = magenta;
                break;
        }
        score = 0;
        health = 100;
        scoreText = GameObject.Find("ScoreCounter").GetComponent<Text>();
        unlockText = GameObject.Find("NextUnlock").GetComponent<Text>();
        bar = GameObject.Find("DynamicBar");
        bar.transform.localScale = new Vector3(1f, 1f);
        ammoText = GameObject.Find("TotalAmmo").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && hero.score >= stage1)
        {
            ThrowFireball();
        }
        if(score >= stage2 && mouvement.speedUpgraded == false)
        {
            mouvement.speedUpgraded = true;
            mouvement.speed *= 2;
        }
        scoreText.text = ("Score : " + score);
        if(score < stage1)
        {
            unlockText.text = ((stage1 - score) + " more points needed to unlock Fireball");
        }
        else if (score >= stage1 && score < stage2)
        {
            unlockText.text = ((stage2 - score) + " more points needed to unlock speed upgrade");
        }
        else if (score >= stage2 && score < stage3)
        {
            unlockText.text = ((stage3 - score) + " more points needed to unlock the next level");
        }
        else if (score >= stage3)
        {
            unlockText.text = ("You can now proceed to the next level");
        }
        updateBars();
    }

    void ThrowFireball()
    {
        GameObject grenade = Instantiate(fireball, transform.position + (transform.right*0.5f), transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward*40f, ForceMode.VelocityChange);
    }

    void updateBars()
    {
        float n = (float)health; //health bar update
        float a = n / 100f;
        bar.transform.localScale = new Vector3(a, 1f);
        ammoText.text = ("Ammo Remaining: " + Gun.bullets); //update number of bullets on person
    }
}
