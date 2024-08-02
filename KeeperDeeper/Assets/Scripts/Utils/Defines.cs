using System;
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
        // Param = Item ID, Item Mount
        public Action<int, int> dropItemAction;

        public Action inventoryRefreshAction;

        // Key = Item ID, Value = Item Mount
        private Dictionary<int, int> items;

        public PlayerInventory()
        {
            items = new Dictionary<int, int>();
        }

        public void AddItem(int itemId)
        {
            if (!items.ContainsKey(itemId))
            {
                items.Add(itemId, 0);
            }
            items[itemId] += 1;
        }

        public void DropItem(int itemId, int mount)
        {
            items[itemId] -= mount;
            if (items[itemId] <= 0)
            {
                items.Remove(itemId);
            }
            inventoryRefreshAction.Invoke();
        }

        public Dictionary<int, int> GetItemList()
        {
            return items;
        }
    }
}
