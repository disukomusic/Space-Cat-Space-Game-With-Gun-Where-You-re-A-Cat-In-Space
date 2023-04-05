using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // goal: be an object or objects on the floor that spawn enemies
    public GameObject enemyPrefab;

    private void Update()
    {
        // todo placeholder, should spawn on its own
        if (Input.GetKeyDown(KeyCode.G))
        {
            // change to be random range later
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }
}
