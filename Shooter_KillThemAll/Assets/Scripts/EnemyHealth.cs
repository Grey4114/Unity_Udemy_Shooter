using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    // This lets other script know the enemies state
    public bool IsDead()
    {
        return isDead;
    }


    public void TakeDamage(float damage)
    {
        // GetComponent<EnemyAI>().OnDamageTaken();   // This is one way to call the method
        BroadcastMessage("OnDamageTaken");   // 2nd method to call method

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
            //Destroy(gameObject);  // Removed - added new Die method
        } 
    }

    private void Die()
    {
        if (isDead) return;  // if the enemy is dead, do not activated the trigger again 

        isDead = true;
        GetComponent<Animator>().SetTrigger("die"); // Activates the die animation
    }
}
