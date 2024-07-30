using System.Collections.Generic;
using UnityEngine;
using static Defines;

public class DataManager : IManagers
{
    public PlayerInventory playerInventory;

    public void Init()
    {
        playerInventory = new PlayerInventory();
    }

}
