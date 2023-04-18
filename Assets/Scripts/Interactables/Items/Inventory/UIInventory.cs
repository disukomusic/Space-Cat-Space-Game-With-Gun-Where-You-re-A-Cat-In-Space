using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// adapated from https://www.youtube.com/watch?v=2WnAOV7nHW0
/// </summary>
public class UIInventory : MonoBehaviour
{
    private Inventory _inventory;
    public Transform itemSlotContainer;
    public GameObject itemSlotTemplate;
    
    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;

        _inventory.OnListItemChanged += Inventory_OnListItemChanged;
    }

    private void Inventory_OnListItemChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }
        foreach (Item item in _inventory.itemList)
        {
            GameObject obj = Instantiate(itemSlotTemplate, itemSlotContainer);
            
            obj.transform.Find("ItemName").GetComponent<TMP_Text>().text = item.itemName;
            obj.transform.Find("ItemIcon").GetComponent<Image>().sprite= item.icon;
            obj.GetComponent<InventoryItemController>().item = item;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RefreshInventoryItems();
        }
    }
}
