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
        if (!spawnItem && canSpawn)
        {
            spawnItem = Instantiate(item, transform.position + new Vector3(0f,0.1f,0f), transform.rotation);
            Debug.Log("spawned item" + spawnItem);
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
    }
}
