using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // [SerializeField] int ammoAmount = 10;  Removes because the new class was created

    [SerializeField] AmmoSlot[] ammoSlots;  // This is an array for the different ammos.

    [System.Serializable]  // This line shows all of the ammos in the Inspector for the object it is attached to.
    private class AmmoSlot // This is a new class
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }


    // Check which ammo type & return the current amount
    public int GetCurrentAmmo(AmmoType ammoType) 
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    // Check which ammo type & reduces the ammo count by 1 each time a weapon is fired 
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    // Check which ammo type & increase the ammo by the amount picked up
    public void IncreaseCurrentAmmo(AmmoType ammoType, int newAmmo)
    {
        GetAmmoSlot(ammoType).ammoAmount += newAmmo;
        //Debug.Log("Ammo Amount: " + GetAmmoSlot(ammoType).ammoAmount );
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            // Matches the weapon ammo slot to the ammo type
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }

}
