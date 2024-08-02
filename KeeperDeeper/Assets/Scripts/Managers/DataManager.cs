using System.Collections.Generic;
using UnityEngine;
using static Defines;

public class DataManager : IManagers
{
    public PlayerInventory playerInventory;

    // Key = Item ID, Value = Item SO
    public Dictionary<int, ItemSO> itemDB = new Dictionary<int, ItemSO>();

    public GameObject itemObj;

    public void Init()
    {
        playerInventory = new PlayerInventory();
        foreach (ItemSO itemSO in Resources.LoadAll<ItemSO>("SO/Item"))
        {
            itemDB.Add(itemSO.itemId, itemSO);
        }
        itemObj = Resources.Load("Prefabs/Item") as GameObject;
    }
}
