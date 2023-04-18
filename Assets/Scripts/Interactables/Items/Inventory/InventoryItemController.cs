using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public void RemoveItem()
    {
        Inventory.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.HealthUp:
                Player.Instance.IncreaseHealth(item.value);
                AlertHandler.Instance.DisplayAlert("HP +" + item.value, Color.green);
                Flasher.Instance.Flash(Color.green, 0.2f);
                RemoveItem();
                break;
            case Item.ItemType.ScoreUp:
                Player.Instance.IncreaseScore(item.value);
                AlertHandler.Instance.DisplayAlert("Score +" + item.value, Color.green);
                RemoveItem();
                break;
            case Item.ItemType.Weapon:
                if (item != WeaponsManager.Instance.equippedWeapon)
                {
                    WeaponsManager.Instance.SetWeapon(item);
                }
                else
                {
                    WeaponsManager.Instance.UnEquip(item);
                }
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
