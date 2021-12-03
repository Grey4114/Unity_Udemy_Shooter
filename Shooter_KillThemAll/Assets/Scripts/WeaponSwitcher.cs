using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;


    void Start()
    {
        SetWeaponActive();
    }

    void Update() 
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    // Using the scroll wheel on the mouse changes the weapon 
    private void ProcessScrollWheel()
    {
        // Changes the weapon on forward/up/increase spin
        if (Input.GetAxis("Mouse ScrollWheel") < 0)   
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        // Changes the weapon on reverse/down/decrease spin
        if (Input.GetAxis("Mouse ScrollWheel") > 0)   
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

    // Pressing a keyboard number 1 - 3 changes the weapon
    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        // Goes through the list of weapons in the Player>Weapons folder
        // 0 - 2: 0 Pistol, 1 Shotgun, 2 Rifle
        foreach(Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex ++;
        }
    }

}    
