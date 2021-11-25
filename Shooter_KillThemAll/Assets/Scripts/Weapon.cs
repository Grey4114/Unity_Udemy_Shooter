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
            // Debug.Log("Bang!! " + hit.transform.name + " was hit!");
            // TODO: addsome hit affect

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            // Error catching - if anything other then enemy is shot, does not return error
            if (target == null) return;

            // Otherwise enemy takes damage
            target.TakeDamage(damage);

        }
        else
        {
            return;
        }
    }
}
