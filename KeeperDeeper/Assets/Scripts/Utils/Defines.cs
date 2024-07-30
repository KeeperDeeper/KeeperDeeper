using System.Collections.Generic;

public class Defines
{
    public enum KeyInputType
    {
        Down,
        Press,
        Up
    }

    public enum MoveDirection
    {
        Left,
        Right
    }

    public enum UIType
    {
        Inventory
    }

    public class PlayerInventory
    {
        List<Item> items;

        public PlayerInventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(new Item(item.itemId, item.itemName, item.itemImg));
        }

        public void DropItem()
        {

        }

        public List<Item> GetItemList()
        {
            return items;
        }
    }
}
