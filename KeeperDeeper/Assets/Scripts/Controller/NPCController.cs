using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    private int npcId;
    private SpriteRenderer npcSprite;
    private Defines.MoveDirection moveDirection;

    void Start()
    {
        npcSprite = GetComponent<SpriteRenderer>();
    }

    void PlayerInteract()
    {
        int likeability = Managers.DataManager.npcDB[npcId].likeability;
        int randomStart = likeability == 0 ? 0 : Managers.DataManager.npcDB[npcId].dialogueRangeByLike[likeability - 1] + 1;
        int randomEnd = Managers.DataManager.npcDB[npcId].dialogueRangeByLike[likeability] + 1;
        int selectedDialogueIdx = Random.Range(randomStart, randomEnd);
        Managers.DialogueManager.TriggerDialogue(Managers.DataManager.npcDB[npcId].dialogueIdList[selectedDialogueIdx]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Player":
                {
                    Managers.IngameManager.interactAction += PlayerInteract;
                    Debug.Log("enter");
                    break;
                }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Player":
                {
                    Managers.IngameManager.interactAction -= PlayerInteract;
                    Debug.Log("exit");
                    break;
                }
        }
    }
}
