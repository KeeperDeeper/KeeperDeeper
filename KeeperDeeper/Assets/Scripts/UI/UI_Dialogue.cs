using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Dialogue : UI_Base, IPointerClickHandler
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
        Managers.DialogueManager.dialogueChoiceSelectAction += ChoiceSelect;
        UpdateDialogue();
    }

    public void UpdateDialogue()
    {
        dialogueTMP.text = "";
        if (isEnd)
        {
            Managers.DialogueManager.dialogueChoiceSelectAction -= ChoiceSelect;
            Destroy(gameObject);
        }
        nameTMP.text = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].name;
        dialogueText = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].dialogue;
        currentTextAnimation = StartCoroutine(DialogueTextAnimation(Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].textAnimationSpeed));
        isEnd = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].isEnd;
    }

    private void ChoiceSelect(int choiceIdx)
    {
        currentIdx = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].choices[choiceIdx].nextIdx;
        UpdateDialogue();
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
        if (Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].choices.Count > 0)
        {
            Managers.DialogueManager.TriggerDialogueChoice(Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].choices);
        }
        else
        {
            currentIdx = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].nextIdx;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isAnimaionPlaying)
            {
                StopCoroutine(currentTextAnimation);
                dialogueTMP.text = dialogueText;
                isAnimaionPlaying = false;
                if (Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].choices.Count > 0)
                {
                    Managers.DialogueManager.TriggerDialogueChoice(Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].choices);
                }
                else
                {
                    currentIdx = Managers.DialogueManager.currentDialogue.dialogueDatas[currentIdx].nextIdx;
                }
            }
            else
            {
                UpdateDialogue();
            }
        }
    }
}
