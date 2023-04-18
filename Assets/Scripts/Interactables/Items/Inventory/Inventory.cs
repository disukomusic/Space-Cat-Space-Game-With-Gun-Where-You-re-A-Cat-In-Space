using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnListItemChanged;
    public List<Item> itemList;

    public static Inventory Instance;

    void Awake()
    {
        Instance = this; 
        itemList = new List<Item>();
    }

    public void Add(Item item)
    {
        itemList.Add(item);
        OnListItemChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Remove(Item item)
    {
        itemList.Remove(item);
    }


}
