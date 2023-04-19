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

    public GameObject HUD;
    public GameObject DeathScreen;
    public TMP_Text finalScoreText;
    public TMP_Text finalWaveText;
    public TMP_Text finalEnemyKillCountText;

    public GameState gameState;
    public static GameManager Instance;
    public event EventHandler Wave;

    public int wave;
    public int enemiesDefeated;
    
    [SerializeField] private float startingHealth;
    [SerializeField] private List<Item> startingItems;
    
    [SerializeField] private UIInventory uiInventory;
    
    [SerializeField] private List<ItemSpawner> itemSpawners;
    
    [SerializeField] private BarrelSpawner barrelSpawner;

    
    [SerializeField] private TMP_Text waveText;
    
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
        
        SoundManager.PlayMusic(SoundManager.Music.IdleMusic);
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
            Wave?.Invoke(this, EventArgs.Empty);
            AlertHandler.Instance.DisplayAlert("New wave incoming! +" + wave + " hp", Color.red);

            Player.Instance.IncreaseHealth(wave);
            Player.Instance.IncreaseScore(wave * 100);

            wave++;
            waveText.text = ("Wave : " + wave);
            yield return new WaitForSeconds(Random.Range(10f, 30f));
        }
    }
}
