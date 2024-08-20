using System.Collections.Generic;
using UnityEngine;
using static Defines;

public class DataManager : IManagers
{
    public PlayerInventory playerInventory;

    // Key = Item ID, Value = Item SO
    public Dictionary<int, ItemSO> itemDB = new Dictionary<int, ItemSO>();

    // Key = Dialogue ID, Value = Dialogue SO
    public Dictionary <int, DialogueSO> dialogueDB = new Dictionary<int, DialogueSO>();

    // Key = NPC ID, Value = NPC SO
    public Dictionary<int, NPCSO> npcDB = new Dictionary<int, NPCSO>();

    public GameObject itemObj;

    public void Init()
    {
        playerInventory = new PlayerInventory();

        foreach (ItemSO itemSO in Resources.LoadAll<ItemSO>("SO/Item"))
        {
            itemDB.Add(itemSO.itemId, itemSO);
        }

        foreach (DialogueSO dialogueSO in Resources.LoadAll<DialogueSO>("SO/Dialogue"))
        {
            dialogueDB.Add(dialogueSO.dialogueId, dialogueSO);
        }

        foreach (NPCSO npcSO in Resources.LoadAll<NPCSO>("SO/NPC"))
        {
            npcDB.Add(npcSO.npcId, npcSO);
        }

        itemObj = Resources.Load("Prefabs/Item") as GameObject;
    }
}
