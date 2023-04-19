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
    [SerializeField] private float subWaitSeconds;
    [SerializeField] private int howManyEnemies;

    private void Awake()
    {
        _objectPooler = GetComponent<EnemyPooler>();
    }

    private void Start()
    {
        SubscribeGameManager();
    }

    public void SubscribeGameManager()
    {
        GameManager.Instance.SpawnEnemies += GameManager_SpawnEnemies;
    }

    private void GameManager_SpawnEnemies(object sender, System.EventArgs e)
    {
        StartCoroutine(SpawnAtTime());
    }


    public void SpawnEnemy()
    {
        Enemy enemy = _objectPooler.CreateEnemyAtPosition(transform.position);
    }

    public IEnumerator SpawnAtTime()
    {
        // todo find out how to make enemies consistently spawn if there are less active than a certain amount
        // simply checking the list's Count wouldn't work as inactive gameObjects are not removed from the list
        for (int i = 0; i < howManyEnemies; i++)
        {
            yield return new WaitForSeconds(subWaitSeconds);
            SpawnEnemy();
        }
    }
}
