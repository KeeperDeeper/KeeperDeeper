using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Item : MonoBehaviour, IPointerClickHandler
{
    public int itemId;

    public void UpdateItemInfo(int itemId)
    {
        this.itemId = itemId;

        name = Managers.DataManager.itemDB[itemId].itemName;
        GetComponent<Image>().sprite = Managers.DataManager.itemDB[itemId].itemImg;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Managers.DataManager.playerInventory.dropItemAction.Invoke(itemId, 1);
        }
    }
}
