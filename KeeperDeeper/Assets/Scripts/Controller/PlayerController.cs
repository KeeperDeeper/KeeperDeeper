using UnityEngine;

/* 플레이어 컨트롤러
 * 플레이어 오브젝트에 직접 집어넣어서 
 */
public class PlayerController : MonoBehaviour, IKeyInput
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpPower = 5.0f;

    private Rigidbody2D rigidbody;

    private bool isGround = false;

    private Defines.MoveStatus facingDirection;

    void Start()
    {
        Init();
    }

    void Init()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        facingDirection = Defines.MoveStatus.MoveRight;

        Managers.InputManager.keyAction += KeyInput;
        Managers.DataManager.playerInventory.dropItemAction += DropItem;
    }

    private void Move(Defines.MoveStatus moveDir)
    {
        switch (moveDir)
        {
            case Defines.MoveStatus.MoveLeft:
                {
                    facingDirection = Defines.MoveStatus.MoveLeft;
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    break;
                }
            case Defines.MoveStatus.MoveRight:
                {
                    facingDirection = Defines.MoveStatus.MoveRight;
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    break;
                }
        }
    }

    private void Jump()
    {
        isGround = false;
        rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void DropItem(int itemId, int mount)
    {
        GameObject itemObj = Instantiate(Managers.DataManager.itemObj, new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), transform.rotation);
        itemObj.GetComponent<Item>().SetItemId(itemId);
        itemObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1), ForceMode2D.Impulse);
        Managers.DataManager.playerInventory.DropItem(itemId, mount);
    }

    public void KeyInput(KeyCode keyCode, Defines.KeyInputType inputType)
    {
        switch (inputType)
        {
            case Defines.KeyInputType.Down:
                {
                    if (keyCode == KeyCode.Space)
                    {
                        if (Managers.IngameManager.isBlockInput)
                            return;
                        if (isGround)
                            Jump();
                    }
                    if (keyCode == KeyCode.Tab)
                    {
                        if (Managers.IngameManager.isBlockInput)
                            return;
                        if (Managers.UIManager.CheckUIMountMargin(Defines.UIType.Inventory, Values.UI_MOUNT_MARGIN_INVENTORY))
                            Managers.UIManager.CreateUI(Defines.UIType.Inventory);
                    }
                    if (keyCode == KeyCode.Escape)
                    {
                        if (Managers.IngameManager.isBlockInput)
                            return;
                        Managers.UIManager.CloseUI();
                    }
                    if (keyCode == KeyCode.E)
                    {
                        if (Managers.IngameManager.isBlockInput)
                        {
                            Managers.DialogueManager.inputWhileDialogue.Invoke();
                        }
                        else
                        {
                            Managers.IngameManager.TryInteract();
                        }
                    }
                    break;
                }
            case Defines.KeyInputType.Press:
                {
                    if (keyCode == KeyCode.A)
                        Move(Defines.MoveStatus.MoveLeft);
                    if (keyCode == KeyCode.D)
                        Move(Defines.MoveStatus.MoveRight);
                    break;
                }
            case Defines.KeyInputType.Up:
                {

                    break;
                }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isGround = true;
                break;
        }
    }
}
