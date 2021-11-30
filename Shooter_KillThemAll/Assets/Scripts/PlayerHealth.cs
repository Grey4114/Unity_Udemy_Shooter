using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void PlayerDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log("Your hit!! "  + damage);
        
        if (hitPoints <= 0)
        {   
            Debug.Log("Your Dead!!");
        }
        
    }

}
