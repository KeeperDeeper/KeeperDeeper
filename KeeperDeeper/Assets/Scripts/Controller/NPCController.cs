using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    private int npcId;
    private SpriteRenderer npcSprite;

    void Start()
    {
        npcSprite = GetComponent<SpriteRenderer>();
    }

    void PlayerInteract()
    {
        Managers.DialogueManager.TriggerDialogue(Managers.DataManager.npcDB[npcId].dialogueIdList[0]);
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
