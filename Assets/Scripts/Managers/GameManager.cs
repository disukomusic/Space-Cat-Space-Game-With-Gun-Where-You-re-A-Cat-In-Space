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
    public TMP_Text finalScoreText;
    public TMP_Text finalWaveText;
    public TMP_Text finalEnemyKillCountText;

    public GameState gameState;
    public static GameManager Instance;
    public event EventHandler Wave;

    public int wave;
    [SerializeField] private TMP_Text waveText;
    [SerializeField]private List<GameObject> newWaveEnemies;

    public int enemiesDefeated;
    
    [SerializeField] private float startingHealth;
    [SerializeField] private List<Item> startingItems;
    
    [SerializeField] private UIInventory uiInventory;
    
    [SerializeField] private List<ItemSpawner> itemSpawners;
    [SerializeField] private List<EnemySpawner> enemySpawners;

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

        StartCoroutine(WaveCoroutine());
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


    IEnumerator WaveCoroutine()
    {
        while (Player.Instance.health > 0)
        {
            wave++;
            waveText.text = ("Wave : " + wave);

            if (wave == 1)
            {
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
                    //this is so stupid do not ever do this 
                    //the null check is not working and i want to die
                    newWaveEnemies.Add(null);
                }

                //yield return new WaitForSeconds(Random.Range(timeBetweenWaves, timeBetweenWaves - 10f));
            yield return new WaitForSeconds(timeBetweenWaves);

        }
    }
}
