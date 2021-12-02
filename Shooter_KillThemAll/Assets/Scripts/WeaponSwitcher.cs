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


    // Update is called once per frame
    void Update()
    {
        
    }

}    
