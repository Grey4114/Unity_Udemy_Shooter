using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;


    // create a public methd that reduces hit points by the amount of damage

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log(hitPoints);

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
        
    }



}
