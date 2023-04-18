using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] List<GameObject> spawnItems;
    
    private GameObject spawnItem;
    private bool spawning;
    private bool canSpawn;
    
    public void InitializeSpawning()
    {
        spawning = true;
        StartCoroutine(spawnTimer(timeBetweenSpawns));
    }

    IEnumerator spawnTimer(float delay)
    {
        yield return new WaitForSeconds(Random.Range(0f,10f));

        while (spawning)
        {
            yield return new WaitForSeconds(delay);
            SpawnItem(spawnItems[Random.Range(0, spawnItems.Count)]);
        }
    }

    void SpawnItem(GameObject item)
    {
        if (!spawnItem.activeInHierarchy && canSpawn)
        {
            spawnItem = Instantiate(item, transform.position, transform.rotation);
            Debug.Log("spawned item" + spawnItem);
            canSpawn = false;
        }
        else
        {
            spawnItem = null;
            canSpawn = true;
        }
    }
}
