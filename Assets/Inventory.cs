using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Action<QItem> onAddItem;
    public List<QItem> inventoryItems = new List<QItem>();
    public int maxItems = 5;

    private void Update()
    {

    }

    public void AddItem(QItem item)
    {
        if (CountCheck())
            inventoryItems.Add(item);
        onAddItem?.Invoke(item);
    }

    public bool CountCheck()
    {
        if (inventoryItems.Count < maxItems)
            return true;
        else return false;
    }

    public int Count()
    {
        return inventoryItems.Count;
    }

    public void RemoveItem(QItem item)
    {
        inventoryItems.Remove(item);
        onAddItem?.Invoke(item);
    }
}