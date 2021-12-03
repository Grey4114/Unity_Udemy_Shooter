using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    // [SerializeField] Ammo ammoSlot;  // For my version


    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            // ammoSlot.IncreaseCurrentAmmo(ammoType, ammoAmount);  My version
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        } 
    }


    // Challenge - My Version
    // private void OnCollisionEnter(Collision other) 
    // {
    //     if (other.collider.CompareTag("Player"))
    //     {
    //         Debug.Log("I hit it");
    //         Destroy(gameObject);
    //     } 
    // }

}
