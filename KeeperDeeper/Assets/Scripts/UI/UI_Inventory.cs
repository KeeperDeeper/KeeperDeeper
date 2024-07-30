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

        foreach (Item item in Managers.DataManager.playerInventory.GetItemList())
        {
            Instantiate(itemUIIconPrefab, itemInstantiateTransform).GetComponent<UI_Item>().UpdateItemInfo(item);
        }
    }
}
