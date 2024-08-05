using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DialogueChoice : UI_Base
{
    private Transform choiceInstantiateTransform;

    private void Awake()
    {
        choiceInstantiateTransform = transform.Find("Choices").transform;
    }

    public void UpdateChoiceList(List<Defines.DialogueChoiceData> choices)
    {
        for (int i = 0; i < choices.Count; i++)
        {
            int currentIdx = i;
            GameObject choiceObj = Instantiate(Managers.DialogueManager.choiceButtonObj, choiceInstantiateTransform);
            choiceObj.transform.Find("Button/Text").GetComponent<TextMeshProUGUI>().text = choices[i].content;
            choiceObj.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => OnClickChoiceButton(currentIdx));
        }
    }

    private void OnClickChoiceButton(int choiceIdx)
    {
        Managers.DialogueManager.dialogueChoiceSelectAction(choiceIdx);
        Destroy(gameObject);
    }
}
