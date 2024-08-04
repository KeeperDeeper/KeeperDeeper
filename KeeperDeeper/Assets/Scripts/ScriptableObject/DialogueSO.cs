using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "ScriptableObject/DialogueSO", order = int.MinValue)]
public class DialogueSO : ScriptableObject
{
    public int dialogueId;
    public List<Defines.DialogueData> dialogueDatas;
}
