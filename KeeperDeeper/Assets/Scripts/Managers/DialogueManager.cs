using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : IManagers
{
    public Action<int> dialogueChoiceSelectAction;

    public DialogueSO currentDialogue;
    public GameObject choiceButtonObj;

    public void Init()
    {
        choiceButtonObj = Resources.Load("Prefabs/UI/UI_DialogueChoiceButton") as GameObject;
    }

    public void TriggerDialogue(int dialogueId)
    {
        currentDialogue = Managers.DataManager.dialogueDB[dialogueId];
        Managers.UIManager.CreateUI(Defines.UIType.Dialogue);
    }

    public void TriggerDialogueChoice(List<Defines.DialogueChoiceData> choices)
    {
        GameObject choiceObj = Managers.UIManager.CreateUI(Defines.UIType.DialogueChoice);
        choiceObj.GetComponent<UI_DialogueChoice>().UpdateChoiceList(choices);
    }
}
