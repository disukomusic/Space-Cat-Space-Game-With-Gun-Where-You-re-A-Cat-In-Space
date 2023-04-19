using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler Instance;
    
    public GameObject enemyPrefab;
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

        GameObject objectToPool = Instantiate(enemyPrefab, position, Quaternion.identity);
        Enemy newEnemy = objectToPool.GetComponent<Enemy>();
        objectPool.Add(newEnemy);
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
