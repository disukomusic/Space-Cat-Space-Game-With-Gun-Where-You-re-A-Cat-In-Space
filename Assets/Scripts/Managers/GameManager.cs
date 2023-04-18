﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private float StartingHealth;
    [SerializeField] private UIInventory uiInventory;
    [SerializeField] private List<Item> startingItems;
    
    private Inventory inventory;
    
    private void Awake()
    {
        Instance = this;
        SoundManager.Initialize();
        

        
        uiInventory.SetInventory(Inventory.Instance);
        
        Player.Instance.SetHealth(StartingHealth);
        Player.Instance.SetScore(0);

    }
    private void Start()
    {
        foreach (Item item in startingItems)
        {
            Inventory.Instance.Add(item);
        }
        SoundManager.PlayMusic(SoundManager.Music.IdleMusic);
    }
    
    public void OnDeath()
    {
        AlertHandler.Instance.DisplayAlert("You would have died if we implemented dying", Color.red);
    }
}
