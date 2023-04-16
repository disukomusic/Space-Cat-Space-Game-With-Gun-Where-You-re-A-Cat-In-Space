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
    [SerializeField] private float waitSecondsTime;
    [SerializeField] private float subWaitSeconds;

    private void Awake()
    {
        _objectPooler = GetComponent<EnemyPooler>();
    }

    private void Start()
    {
        StartCoroutine(SpawnAtTime());
    }
    

    public void SpawnEnemy()
    {
        
        Enemy enemy = _objectPooler.CreateGameObject(transform.position);
    }

    public IEnumerator SpawnAtTime()
    {
        // currently spawns enemies at the spawn point after waitSecondsTime has passed,
        // and spawns 10 enemies every subWaitSeconds.
        // todo check the count of the object pooler list to spawn in enemies if it is less than a certain number
        yield return new WaitForSeconds(waitSecondsTime);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(subWaitSeconds);
            SpawnEnemy();
        }
    }
}
