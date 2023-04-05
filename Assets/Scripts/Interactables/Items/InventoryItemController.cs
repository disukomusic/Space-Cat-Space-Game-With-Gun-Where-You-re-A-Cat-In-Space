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
                RemoveItem();
                break;
            case Item.ItemType.ScoreUp:
                Player.Instance.IncreaseScore(item.value);
                RemoveItem();
                break;
            case Item.ItemType.Weapon:
                WeaponsManager.Instance.SetWeapon(item);
                break;
            case Item.ItemType.Trophy:
                Debug.Log("weeee trophy time");
                break;
            case Item.ItemType.Test:
                Debug.Log("test item what the fuck");
                RemoveItem();
                break;
        }


    }
}
