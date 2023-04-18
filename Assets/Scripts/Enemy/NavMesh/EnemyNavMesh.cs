using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

// all from that "pathfinding in 6 minutes" video. desperately needs refactoring, literally everything AI is done in this script
// some of the things done in the video are already present in other places, thus I did not follow
public class EnemyNavMesh : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public Enemy enemy;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    
    // patrolling
    public Vector3 walkPoint;
    private bool _walkPointSet;
    public float walkPointRange = 5;
    
    // attacking
    public float timeBetweenAttacks = 0.5f;
    private bool _alreadyAttacked;
    
    // states
    public float sightRange = 12f;
    public float attackRange = 1f;
    public bool playerInSightRange, playerInAttackRange = false;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patrolling()
    {
        if (!_walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            _navMeshAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        // when walkpoint is reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            _walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            _walkPointSet = true;
        }
    }

    public void ChasePlayer()
    {
        _navMeshAgent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        _navMeshAgent.SetDestination(transform.position);
        
        transform.LookAt(player);
        StartCoroutine(attack(timeBetweenAttacks));
        _alreadyAttacked = true;

    }


    private IEnumerator attack(float delay)
    {
        if (!_alreadyAttacked)
        {
            yield return new WaitForSeconds(delay);
            Player.Instance.HitPlayer(enemy.damage);
        }
        _alreadyAttacked = false;
        
    }
}
