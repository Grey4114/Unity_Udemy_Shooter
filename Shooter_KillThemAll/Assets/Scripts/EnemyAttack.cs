using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 20f;


    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();  // finds the player, could also use fid by tag "player"
    }

    public void AttackHitEvent()
    {
        Debug.Log("HiT");
        if (target == null) return;


        // My code
        //PlayerHealth player = target.GetComponent<PlayerHealth>();  
        //player.PlayerDamage(damage);

        target.PlayerDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();  // Shows player Damage  

        //Debug.Log("Bang! Hit you!");



    }

}
