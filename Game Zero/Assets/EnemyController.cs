using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;

    private NavMeshAgent navMeshAgent;

    public GameObject Player;

    public GameObject EnemyGFX;

    public GameObject targetObject;

    public float AttackDistance = 10f;

    public float FollowDistance = 20f;

    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;

    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 0.5f;

    public int DamagePoints = 2;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = EnemyGFX.GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        bool shoot = false;
        bool follow = (distance < FollowDistance);
        bool idle = !follow;

        if (follow)
        {
            float random = Random.Range(0.0f, 1.0f);
            if (random > (1.0f - AttackProbability) && distance < AttackDistance)
            {
                shoot = true;
                follow = false;
            }
        }

        if (follow)
        {
            navMeshAgent.SetDestination(Player.transform.position);
        }

        if (!follow || shoot)
        {
            navMeshAgent.SetDestination(transform.position);
        }

        if (!follow && !shoot)
        {
            navMeshAgent.SetDestination(targetObject.transform.position);
            idle = false;
            follow = true;
        }

        animator.SetBool("idle", idle);      
        animator.SetBool("shoot", shoot);
        animator.SetBool("run", follow);
    }

    public void ShootEvent()
    {
        float random = Random.Range(0.0f, 1.0f);

        bool isHit = random > (1.0f - HitAccuracy);

        if (isHit)
        {
            Player.GetComponent<PlayerStats>().TakeDamage(2);
        }
    }
}
