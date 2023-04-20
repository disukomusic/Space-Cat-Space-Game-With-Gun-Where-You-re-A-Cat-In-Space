using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] List<GameObject> spawnItems;

    private GameObject spawnItem;
    private bool spawning;
    private bool canSpawn = true;
    
    public void InitializeSpawning()
    {
        spawning = true;
        StartCoroutine(SpawnTimer(timeBetweenSpawns));
    }

    IEnumerator SpawnTimer(float delay)
    {
        yield return new WaitForSeconds(Random.Range(0f,delay));

        while (spawning)
        {
            SpawnItem(spawnItems[Random.Range(0, spawnItems.Count)]);
            yield return new WaitForSeconds(delay + Random.Range(-5f,5f));
        }
    }

    void SpawnItem(GameObject item)
    {
        if (!spawnItem && canSpawn)
        {
            spawnItem = Instantiate(item, transform.position + new Vector3(0f,1f,0f), transform.rotation);
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
    }
}
