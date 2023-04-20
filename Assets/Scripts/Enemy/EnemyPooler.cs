using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler Instance;
    
    public List<GameObject> enemyPrefab;
    public List<Enemy> objectPool;
    public float enemyCount;

    private void Awake()
    {
        Instance = this;
        objectPool = new List<Enemy>();
    }

    public Enemy CreateEnemyAtPosition(Vector3 position)
    {
        foreach (var enemy in objectPool)
        {
            // activeInHierachy in case parent is deactivated, as the children would still technically be active
            if (!enemy.gameObject.activeInHierarchy)
            {
                enemy.ResetSelf();
                // reset the gameObject position
                enemy.transform.position = position;
                return enemy;
            }
        }

        GameObject objectToPool = Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Count - 1)], position, Quaternion.identity);
        Enemy newEnemy = objectToPool.GetComponent<Enemy>();
        objectPool.Add(newEnemy);
        enemyPrefab.Clear();
        return newEnemy;
    }

    public void KillAllEnemies()
    {
        foreach (var enemy in objectPool)
        {
            if (enemy.gameObject)
            {
                Destroy(enemy.gameObject);
            }
        }
        objectPool.Clear();
        
    }
}
