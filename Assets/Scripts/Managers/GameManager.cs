using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event EventHandler SpawnEnemies;

    public int wave;
    
    [SerializeField] private float startingHealth;
    [SerializeField] private List<Item> startingItems;
    
    [SerializeField] private UIInventory uiInventory;
    
    [SerializeField] private List<ItemSpawner> itemSpawners;
    
    [SerializeField] private TMP_Text waveText;
    
    private Inventory inventory;
    
    private void Awake()
    {
        //LETS FUCKING GOOOOO
        Instance = this;
        SoundManager.Initialize();
        
        uiInventory.SetInventory(Inventory.Instance);
        
        Player.Instance.SetHealth(startingHealth);
        Player.Instance.SetScore(0);

    }
    private void Start()
    {
        foreach (Item item in startingItems)
        {
            Inventory.Instance.Add(item);
        }

        foreach (ItemSpawner spawner in itemSpawners)
        {
            spawner.InitializeSpawning();
        }

        StartCoroutine(EnemySpawn());
        
        SoundManager.PlayMusic(SoundManager.Music.IdleMusic);
    }
    
    public void OnDeath()
    {
        AlertHandler.Instance.DisplayAlert("You would have died if we implemented dying", Color.red);
    }


    IEnumerator EnemySpawn()
    {
        while (Player.Instance.health > 0)
        {
            SpawnEnemies?.Invoke(this, EventArgs.Empty);
            AlertHandler.Instance.DisplayAlert("New wave incoming!",  Color.red);
            wave++;
            waveText.text = ("Wave : " + wave);
            yield return new WaitForSeconds(Random.Range(10f,30f));
        }
    }
}
