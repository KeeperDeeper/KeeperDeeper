using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : IManagers
{
    public DialogueSO currentDialogue;

    public void Init()
    {

    }

    public void TriggerDialogue(int dialogueId)
    {
        currentDialogue = Managers.DataManager.dialogueDB[dialogueId];
        Managers.UIManager.CreateUI(Defines.UIType.Dialogue);
    }
}
