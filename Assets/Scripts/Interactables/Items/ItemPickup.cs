using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        Inventory.Instance.Add(item);
        AlertHandler.Instance.DisplayAlert("Picked Up: " + item.name, Color.magenta);
        Destroy(gameObject);
    }
}
