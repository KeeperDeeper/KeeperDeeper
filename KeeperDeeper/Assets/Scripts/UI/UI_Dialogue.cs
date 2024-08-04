using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Dialogue : UI_Base, IMouseInput
{
    private const string nameDir = "BG_Name/Value";
    private const string dialogueDir = "BG_Dialogue/Value";

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;
    private int currentIdx;
    private bool isEnd;

    private void Start()
    {
        nameText = transform.Find(nameDir).GetComponent<TextMeshProUGUI>();
        dialogueText = transform.Find(dialogueDir).GetComponent<TextMeshProUGUI>();
        currentIdx = 0;

        Managers.InputManager.mouseInputAction += MouseInput;

        UpdateDialogue();
    }

    public void UpdateDialogue()
    {
        if (isEnd)
        {
            Managers.InputManager.mouseInputAction -= MouseInput;
            Destroy(gameObject);
        }
        nameText.text = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].name;
        dialogueText.text = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].dialogue;
        isEnd = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].isEnd;
        currentIdx = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].nextIdx;
    }

    public void MouseInput(MouseButton button, Defines.MouseInputType inputType)
    {
        switch (inputType)
        {
            case Defines.MouseInputType.Down:
                {
                    if (button == MouseButton.Left)
                    {
                        UpdateDialogue();
                    }
                    break;
                }
        }
    }
}
