using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
{

    public int selectedWeapon = 0; //index of weapon

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previouslySelectedWeapon = selectedWeapon; 
        if(Input.GetAxis("Mouse ScrollWheel") > 0f) //scroll up
        {
            if(selectedWeapon >= transform.childCount - 1) //sets boundary for number of weapons 
            {
                selectedWeapon =0;
            }
            else
            {
                selectedWeapon++;
            }
            
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0f) //scroll down
        {
            if (selectedWeapon <= transform.childCount - 1) //sets boundary no min 
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon--;
            }

        }
        if (previouslySelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform) //loops though all weapons 
        { 
            if (i== selectedWeapon) //sets the weapon of correct index to active 
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false); //sets all other weapons to not active 
            }
            i++;
        }
    }
}
