using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking.Types;
using static Defines;

public class NPCController : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    [SerializeField]
    private int npcId;
    private SpriteRenderer npcSprite;
    private Defines.MoveStatus moveStatus;
    private float moveStatusInitilizeTime = 1.0f;

    private Vector3 initPosition;
    private float moveLimit = 4.0f;

    void Start()
    {
        initPosition = transform.position;
        npcSprite = GetComponent<SpriteRenderer>();
        moveStatus = MoveStatus.Idle;
        StartCoroutine(ChangeMoveStatus());
    }

    void Update()
    {
        Move();
    }

    IEnumerator ChangeMoveStatus()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(5.0f, 10.0f));
            moveStatus = (Defines.MoveStatus)(UnityEngine.Random.Range(0, 2) + 1);
            StartCoroutine(InitializeMoveStatus());
        }
    }

    IEnumerator InitializeMoveStatus()
    {
        yield return new WaitForSeconds(moveStatusInitilizeTime);
        moveStatus = MoveStatus.Idle;
    }

    void Move()
    {
        switch (moveStatus)
        {
            case MoveStatus.Idle:
                {
                    break;
                }

            case MoveStatus.MoveLeft:
                {
                    if (Vector2.Distance(initPosition, transform.position) >= moveLimit && initPosition.x > transform.position.x)
                    {
                        moveStatus = MoveStatus.MoveRight;
                        break;
                    }
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    break;
                }

            case MoveStatus.MoveRight:
                {
                    if (Vector2.Distance(initPosition, transform.position) >= moveLimit && initPosition.x < transform.position.x)
                    {
                        moveStatus = MoveStatus.MoveLeft;
                        break;
                    }
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    break;
                }
        }
    }

    void PlayerInteract()
    {
        int likeability = Managers.DataManager.npcDB[npcId].likeability;
        int randomStart = likeability == 0 ? 0 : Managers.DataManager.npcDB[npcId].dialogueRangeByLike[likeability - 1] + 1;
        int randomEnd = Managers.DataManager.npcDB[npcId].dialogueRangeByLike[likeability] + 1;
        int selectedDialogueIdx = UnityEngine.Random.Range(randomStart, randomEnd);
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
