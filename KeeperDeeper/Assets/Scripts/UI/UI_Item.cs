using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Item : MonoBehaviour
{
    public int itemId;
    public string itemName;
    public Sprite itemImg;

    public void UpdateItemInfo(int itemId)
    {
        this.itemId = itemId;
        itemName = Managers.DataManager.itemDB[itemId].itemName;
        itemImg = Managers.DataManager.itemDB[itemId].itemImg;

        name = itemName;
        GetComponent<Image>().sprite = itemImg;
    }
}
