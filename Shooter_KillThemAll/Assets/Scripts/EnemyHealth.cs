using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        // GetComponent<EnemyAI>().OnDamageTaken();   // This is one way to call the method
        BroadcastMessage("OnDamageTaken");   // 2nd method to call method

        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        } 
    }
}
