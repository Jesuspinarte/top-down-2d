using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<string, int> items = new Dictionary<string, int>();

    public int GetCount(string item)
    {
        if (items.ContainsKey(item))
            return items[item];
        return 0;
    }

    public void Add(string item, int count)
    {
        if (items.ContainsKey(item))
            items[item] += count;
        else
            items[item] = count;
    }

    public void Remove(string item, int count = -1)
    {
        if (!items.ContainsKey(item)) return;

        int newCount = items[item] - count;

        if (count <= -1 || newCount < 1)
            items.Remove(item);
        else
            items[item] = newCount;

    }

    public string GetInventoryString()
    {
        string inventoryList = "Inventory: \n";

        foreach (string item in items.Keys)
        {
            inventoryList += items[item] + "x " + item + "\n";
        }

        return inventoryList;
    }
}
