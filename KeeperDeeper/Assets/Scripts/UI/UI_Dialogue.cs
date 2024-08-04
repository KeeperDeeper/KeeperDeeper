using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Dialogue : UI_Base, IMouseInput
{
    private const string nameDir = "BG_Name/Value";
    private const string dialogueDir = "BG_Dialogue/Value";

    private TextMeshProUGUI nameTMP;
    private TextMeshProUGUI dialogueTMP;
    private Coroutine currentTextAnimation;
    private string dialogueText;
    private int currentIdx;
    private bool isEnd;
    private bool isAnimaionPlaying;

    private void Start()
    {
        nameTMP = transform.Find(nameDir).GetComponent<TextMeshProUGUI>();
        dialogueTMP = transform.Find(dialogueDir).GetComponent<TextMeshProUGUI>();
        currentIdx = 0;

        Managers.InputManager.mouseInputAction += MouseInput;

        UpdateDialogue();
    }

    public void UpdateDialogue()
    {
        dialogueTMP.text = "";
        if (isEnd)
        {
            Managers.InputManager.mouseInputAction -= MouseInput;
            Destroy(gameObject);
        }
        nameTMP.text = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].name;
        dialogueText = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].dialogue;
        currentTextAnimation = StartCoroutine(DialogueTextAnimation(Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].textAnimationSpeed));
        isEnd = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].isEnd;
        currentIdx = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].nextIdx;
    }

    IEnumerator DialogueTextAnimation(float speed)
    {
        isAnimaionPlaying = true;
        for (int i = 0; i < dialogueText.Length; i++)
        {
            dialogueTMP.text += dialogueText[i];
            yield return new WaitForSeconds(speed);
        }
        isAnimaionPlaying = false;
    }

    public void MouseInput(MouseButton button, Defines.MouseInputType inputType)
    {
        switch (inputType)
        {
            case Defines.MouseInputType.Down:
                {
                    if (button == MouseButton.Left)
                    {
                        if (isAnimaionPlaying)
                        {
                            StopCoroutine(currentTextAnimation);
                            dialogueTMP.text = dialogueText;
                            isAnimaionPlaying = false;
                        }
                        else
                        {
                            UpdateDialogue();
                        }
                    }
                    break;
                }
        }
    }
}
