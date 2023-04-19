using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarrelSpawner : MonoBehaviour
{     
    public GameObject barrelPrefab;

    private void Start()
    {
        SubscribeGameManager();
    }

    public void SubscribeGameManager()
    {
        GameManager.Instance.Wave += GameManagerWave;
    }
    private void GameManagerWave(object sender, System.EventArgs e)
    {
        StartCoroutine(BarrelSpawn(GameManager.Instance.wave));
    }

    IEnumerator BarrelSpawn(int howMany)
    {
        if (howMany > 10)
        {
            howMany = 10;
        }
        for(int i = 0; i < howMany; i++)
        {
            SpawnBarrelAtRandomPosition();
            yield return null;
        }
    }

    public void SpawnBarrelAtRandomPosition()
    {
        Vector3 pos = GetRandomPosition();
        Instantiate(barrelPrefab, pos, quaternion.identity);
    }
    
    public Vector3 GetRandomPosition()
    {
        float x = Random.Range(-23f, 130f);
        float z = Random.Range(10f, -61f);

        return new Vector3(x, 35, z);
    }
}
