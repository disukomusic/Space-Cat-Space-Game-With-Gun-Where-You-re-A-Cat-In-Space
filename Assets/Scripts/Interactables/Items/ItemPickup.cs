using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        InventoryManager.Instance.Add(item);
        AlertHandler.Instance.DisplayAlert("Picked Up" + item.name, Color.magenta);
        Destroy(gameObject);
    }
}
