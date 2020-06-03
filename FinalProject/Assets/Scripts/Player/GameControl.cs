using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private GameObject customizeMenu; //for menu items and control
    private Button continueButton;
    private Text warningMessage;
    private bool isOpen;

    int healthValue; //holds customized values 
    int damageValue;
    int speedValue;

    private InputField healthInput; //input feilds for data retrieval
    private InputField damageInput;
    private InputField speedInput;

    public Material green; //set of colours to choose from
    public Material yellow;
    public Material blue;
    public Material magenta;

    private GameObject playerPrototype; //displayed version of character for user feedback

    void Start()
    {
        customizeMenu = GameObject.Find("CustomizationScreen"); //finds the customization screen from hierarchy
        customizeMenu.SetActive(false); //makes the menu invisible until needed
        isOpen = false;
    }

    void Update()
    {
        if (isOpen) //will run if customization menu is open
        {
            try
            {
                healthValue = int.Parse(healthInput.text); //retrieves input value and converts to integer type
                damageValue = int.Parse(damageInput.text);
                speedValue = int.Parse(speedInput.text);
            }
            catch (Exception e) { }
            continueButton.interactable = false;
            if (healthValue + damageValue + speedValue != 10)
            {
                warningMessage.text = ("Your total stats must be equal to 10"); //shows warning message wtih reason
                continueButton.interactable = false; //prevents user from proceeding if values are incorrect
            }
            else
            {
                warningMessage.text = "";
                continueButton.interactable = true; //allows user to continue is values are acceptable
            }
        }
    }

    public void OpenMenu()
    {
        customizeMenu.SetActive(true); //shows customization menu
        isOpen = true;
        healthInput = GameObject.Find("ArmourStat").GetComponent<InputField>(); //finds the text fields for each stat
        damageInput = GameObject.Find("DamageStat").GetComponent<InputField>();
        speedInput = GameObject.Find("SpeedStat").GetComponent<InputField>();
        
        continueButton = GameObject.Find("ContinueButton").GetComponent<Button>();
        warningMessage = GameObject.Find("CautionLabel").GetComponent<Text>();
        warningMessage.text = ""; //removes warning message if values are acceptable

        playerPrototype = GameObject.Find("PlayerProto");
    }

    public void CloseMenu()
    {
        //print(healthValue + "," + damageValue + "," + speedValue);
        PlayerPrefs.SetInt("healthInc", healthValue);
        PlayerPrefs.SetInt("damageInc", damageValue);
        PlayerPrefs.SetInt("speedInc", speedValue);
        customizeMenu.SetActive(false); //closes customization menu
    }

    public void SetColour(String input)
    {
        switch (input)
        {
            case ("YELLOW"):
                playerPrototype.GetComponent<MeshRenderer>().material = yellow; //sets player's colour
                PlayerPrefs.SetString("colour", "yellow"); //passes data to new scene
                break;
            case ("GREEN"):
                playerPrototype.GetComponent<MeshRenderer>().material = green;
                PlayerPrefs.SetString("colour", "green");
                break;
            case ("BLUE"):
                playerPrototype.GetComponent<MeshRenderer>().material = blue;
                PlayerPrefs.SetString("colour", "blue");
                break;
            case ("MAGENTA"):
                playerPrototype.GetComponent<MeshRenderer>().material = magenta;
                PlayerPrefs.SetString("colour", "magenta");
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("firstLevel"); //starts the next scene
    }
}
