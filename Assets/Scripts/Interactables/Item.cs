using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable 
{ 
    public int id; 
    public string title; 
    public string description; 
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();
    
    public Item(int id, string title, string description, Dictionary<String,int> stats, Sprite icon)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.stats = stats;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);

    }
}
