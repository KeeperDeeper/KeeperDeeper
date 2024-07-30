using System.Collections;
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

        // key = Item Id, Value = Item Mount
        foreach (KeyValuePair<int, int> itemData in Managers.DataManager.playerInventory.GetItemList())
        {
            GameObject itemUIIconObj = Instantiate(itemUIIconPrefab, itemInstantiateTransform);
            itemUIIconObj.GetComponent<UI_Item>().UpdateItemInfo(itemData.Key);
        }
    }
}
