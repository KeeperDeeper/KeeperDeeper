using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/ItemSO", order = int.MinValue)]
public class ItemSO : ScriptableObject
{
    public int itemId;
    public string itemName;
    public Sprite itemImg;
}
