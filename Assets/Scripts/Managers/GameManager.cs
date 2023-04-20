using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Gaming,
        Death,
    }

    
    [SerializeField] private float timeBetweenWaves;
    
    public GameObject HUD;
    public GameObject DeathScreen;
    public GameObject cheatCodes;
    
    
    public TMP_Text finalScoreText;
    public TMP_Text finalWaveText;
    public TMP_Text finalEnemyKillCountText;

    public GameState gameState;
    public static GameManager Instance;
    public event EventHandler Wave;

    public int wave;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private List<GameObject> newWaveEnemies;

    public int enemiesDefeated;
    
    [SerializeField] private float startingHealth;
    [SerializeField] private List<Item> startingItems;
    
    [SerializeField] private UIInventory uiInventory;
    
    [SerializeField] private List<ItemSpawner> itemSpawners;
    [SerializeField] private List<EnemySpawner> enemySpawners;
    [SerializeField] private List<Teleporter> teleporters;


    public BarrelSpawner barrelSpawner;

    
    private Inventory inventory;
    
    private void Awake()
    {
        //LETS FUCKING GOOOOO
        Instance = this;
        gameState = GameState.Gaming;
        SoundManager.Initialize();
        
        DeathScreen.SetActive(false);
        HUD.SetActive(true);
        cheatCodes.SetActive(false);

        
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

        foreach (Teleporter teleporter in teleporters)
        {
            teleporter.gameObject.SetActive(false);
        }

        StartCoroutine(WaveCoroutine());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (cheatCodes.activeInHierarchy)
            {
                cheatCodes.SetActive(false);
            }
            else
            {
                cheatCodes.SetActive(true);
            }
        }    
    }
    
    IEnumerator WaveCoroutine()
    {
        while (Player.Instance.health > 0)
        {
            wave++;
            waveText.text = ("Wave : " + wave);

            if (wave == 1)
            {
                EnableTeleporters();

                SoundManager.PlayMusic(SoundManager.Music.Wave1);
            }
            else if (wave == 5)
            {
                SoundManager.PlayMusic(SoundManager.Music.Wave5);
            }
            else if (wave == 7)
            {
                SoundManager.PlayMusic(SoundManager.Music.Wave7);
            }
            else if (wave == 10)
            {
                SoundManager.PlayMusic(SoundManager.Music.Wave10);
            }
            
            Wave?.Invoke(this, EventArgs.Empty);
            AlertHandler.Instance.DisplayAlert("New wave incoming!", Color.red);

            Player.Instance.IncreaseHealth(wave * 5f);
            Player.Instance.IncreaseScore(wave * 100);
            
                if (newWaveEnemies[wave] != null)
                {
                    foreach (EnemySpawner spawner in enemySpawners)
                    {
                        spawner.enemyPrefab.Add(newWaveEnemies[wave]);
                    }
                }
                else
                {
                    //apparently checking for null doesn't work if the null is... null?
                    //there is no slot for a gameobject on the next index sooooo we add one :) [agony]
                    newWaveEnemies.Add(null);
                    //this is so stupid do not ever do this 
                }
                yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
    public void OnDeath()
    {
        gameState = GameState.Death;
        StopAllCoroutines();

        DeathScreen.SetActive(true);
        HUD.SetActive(false);

        EnemyPooler.Instance.KillAllEnemies();
        
        finalScoreText.text = Player.Instance.score.ToString();
        finalWaveText.text = wave.ToString();
        finalEnemyKillCountText.text = enemiesDefeated.ToString();
        
        Player.Instance.GetComponent<PlayerAnimate>().CatJazz();
    }

    void EnableTeleporters()
    {
        foreach (Teleporter teleporter in teleporters)
        {
            teleporter.gameObject.SetActive(true);
            AlertHandler.Instance.DisplayAlert("Teleporters Active!", Color.green);
        }
    }
}
