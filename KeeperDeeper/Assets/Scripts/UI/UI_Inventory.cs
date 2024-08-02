using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Base
{
    [SerializeField]
    private Transform itemInstantiateTransform;

    [SerializeField]
    private GameObject itemUIIconPrefab;

    private void Awake()
    {
        itemInstantiateTransform = transform.Find("Scroll View/Viewport/Content");
        itemUIIconPrefab = Resources.Load("Prefabs/UI/UI_Item") as GameObject;

        ShowInventory();

        Managers.DataManager.playerInventory.inventoryRefreshAction += ShowInventory;
    }

    private void ShowInventory()
    {
        foreach (Transform child in itemInstantiateTransform)
        {
            Destroy(child.gameObject);
        }

        // Key = Item Id, Value = Item Mount
        foreach (KeyValuePair<int, int> itemData in Managers.DataManager.playerInventory.GetItemList())
        {
            GameObject itemUIIconObj = Instantiate(itemUIIconPrefab, itemInstantiateTransform);
            itemUIIconObj.GetComponent<UI_Item>().UpdateItemInfo(itemData.Key);
        }
    }
}
