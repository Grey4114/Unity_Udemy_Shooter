using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;    
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    EnemyHealth health;
    Transform target;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
    }


    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;  // Turns off the EnemyAI script
            navMeshAgent.enabled = false;  // Turns off the Nav Mesh
        }
        
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }    
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            Debug.Log("Attack");
            AttackTarget();
        }
        
    }


    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    // Get the enemy to turn and face the player
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;  // new variable
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);  
        // Slerp - means spherical interpolation
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        // Gizmos.color = new Color(1, 1, 0, 0.75F);
        // Gizmos.DrawSphere(transform.position, explosionRadius);
    }        

}
