using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // DeathHandler menu;  // My version
    [SerializeField] float hitPoints = 100f;

    public void PlayerDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log("Your hit!! "  + damage);
        
        if (hitPoints <= 0)
        {   
            GetComponent<DeathHandler>().HandleDeath();

            // Debug.Log("Your Dead!!");

            // My version
            // menu = FindObjectOfType<DeathHandler>();
            // menu.HandleDeath();
        }
        
    }

}
