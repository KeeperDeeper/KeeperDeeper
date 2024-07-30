using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Item : MonoBehaviour
{
    public int itemId;
    public string itemName;
    public Sprite itemImg;

    public void UpdateItemInfo(Item item)
    {
        itemId = item.itemId;
        itemName = item.itemName;
        itemImg = item.itemImg;

        name = itemName;
        GetComponent<Image>().sprite = itemImg;
    }
}
