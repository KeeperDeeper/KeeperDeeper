using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public void TriggerDialogue()
    {
        Managers.DialogueManager.TriggerDialogue(1);
    }
}
