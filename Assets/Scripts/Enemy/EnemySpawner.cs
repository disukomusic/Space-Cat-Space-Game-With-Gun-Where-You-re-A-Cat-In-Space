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
    [SerializeField] private int howManyEnemies;

    private void Awake()
    {
        _objectPooler = GetComponent<EnemyPooler>();
    }

    private void Start()
    {
        StartCoroutine(SpawnAtTime());
    }


    private void Update()
    {
        if (_objectPooler.enemyCount < 1)
        {
            //this is fucking dumb
            //todo: enemy spawner 
            SpawnEnemy();
            SpawnEnemy();
            SpawnEnemy();
            SpawnEnemy();
            SpawnEnemy();

        }
    }

    public void SpawnEnemy()
    {
        
        Enemy enemy = _objectPooler.CreateGameObject(transform.position);
    }

    public IEnumerator SpawnAtTime()
    {
        // currently spawns enemies at the spawn point after waitSecondsTime has passed,
        // and spawns 10 enemies every subWaitSeconds.
        // todo find out how to make enemies consistently spawn if there are less active than a certain amount
        // simply checking the list's Count wouldn't work as inactive gameObjects are not removed from the list
        yield return new WaitForSeconds(waitSecondsTime);
        for (int i = 0; i < howManyEnemies; i++)
        {
            
            yield return new WaitForSeconds(subWaitSeconds);
            SpawnEnemy();
        }
    }
}
