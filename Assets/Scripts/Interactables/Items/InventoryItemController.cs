using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    private Item item;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
    
    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.HealthUp:
                Player.Instance.IncreaseHealth(item.value);
                AlertHandler.Instance.DisplayAlert("HP +" + item.value, Color.green);
                RemoveItem();
                break;
            case Item.ItemType.ScoreUp:
                Player.Instance.IncreaseScore(item.value);
                AlertHandler.Instance.DisplayAlert("Score +" + item.value, Color.green);
                RemoveItem();
                break;
            case Item.ItemType.Weapon:
                WeaponsManager.Instance.SetWeapon(item);
                break;
            case Item.ItemType.Trophy:
                AlertHandler.Instance.DisplayAlert("Trophy!! wow!!!!", Color.cyan);
                break;
            case Item.ItemType.Test:
                AlertHandler.Instance.DisplayAlert("This is a test item how the fuck did you get this", Color.cyan);
                RemoveItem();
                break;
        }


    }
}
