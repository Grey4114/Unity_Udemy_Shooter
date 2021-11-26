using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100F;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFlash;

    // Needs to be GameOject, not ParticleSytem to be instantiated and Destroyed
    [SerializeField] GameObject hitEffect; 


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    // Raycasting for weapon shot
    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            
            CreateHitImpact();
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            // Error catching - if anything other then enemy is shot, does not return error
            if (target == null) return;

            // Otherwise enemy takes damage
            target.TakeDamage(damage); // Calls EnemyHealth and Deals Damage 

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            // LookRotation has the object faces the camera
            // hit.normal has the effect face away from the objevt hit, towards the player
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, .1f);

        }
    }
}
