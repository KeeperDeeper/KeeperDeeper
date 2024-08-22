using System;
using UnityEngine;

public class IngameManager : IManagers
{
    public Action interactAction;
    public bool isBlockInput;

    public void Init()
    {
        isBlockInput = false;
    }

    public void TryInteract()
    {
        if (interactAction != null)
        {
            interactAction.Invoke();
        }
    }
}
