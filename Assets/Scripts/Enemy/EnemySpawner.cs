using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    // goal: be an object or objects on the floor that spawn enemies
    private EnemyPooler _objectPooler;
    public GameObject enemyPrefab;

    private void Awake()
    {
        _objectPooler = GetComponent<EnemyPooler>();
    }

    public void SpawnEnemy()
    {
        
        Enemy enemy = _objectPooler.CreateGameObject(transform.position);
    }
    private void Update()
    {
        // todo placeholder, should spawn on its own
        if (Input.GetKeyDown(KeyCode.G))
        {
           SpawnEnemy();
        }
    }
}
