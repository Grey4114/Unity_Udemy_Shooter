using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 70f;
    [SerializeField] float intensityAmount = 2f;

    // [SerializeField] FlashLightSystem FlashLight;  // Mine


    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            // FlashLight.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle); // Mine
            // FlashLight.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(intensityAmount);  //Mine


            // other = Player
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);  // Teacher
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(intensityAmount);   //Teacher
            Destroy(gameObject);
        } 
    }

}
