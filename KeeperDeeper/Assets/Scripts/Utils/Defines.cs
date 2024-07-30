using System.Collections.Generic;
using static UnityEditor.Progress;

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
        // Key = Item ID, Value Item Mount
        Dictionary<int, int> items;

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

        public void DropItem(int itemId)
        {

        }

        public Dictionary<int, int> GetItemList()
        {
            return items;
        }
    }
}
