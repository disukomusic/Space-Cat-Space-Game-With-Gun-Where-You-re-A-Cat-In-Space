using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshSimple : MonoBehaviour
{
    private Transform movePosTransform;
    private NavMeshAgent _navMeshAgent;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        movePosTransform = GameObject.Find("Player").transform;
    }

    private void Update()

    {
        _navMeshAgent.destination = movePosTransform.position;
    }
}
