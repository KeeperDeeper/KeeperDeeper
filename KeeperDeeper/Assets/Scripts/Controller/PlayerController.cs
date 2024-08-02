using UnityEngine;

public class PlayerController : MonoBehaviour, IKeyInput
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpPower = 20.0f;

    private Rigidbody2D rigidbody;

    private bool isGround = false;

    private Defines.MoveDirection facingDirection;

    void Start()
    {
        Init();
    }

    void Init()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        facingDirection = Defines.MoveDirection.Right;

        Managers.InputManager.keyAction += KeyInput;
        Managers.DataManager.playerInventory.dropItemAction += DropItem;
    }

    private void Move(Defines.MoveDirection moveDir)
    {
        switch (moveDir)
        {
            case Defines.MoveDirection.Left:
                {
                    facingDirection = Defines.MoveDirection.Left;
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    break;
                }
            case Defines.MoveDirection.Right:
                {
                    facingDirection = Defines.MoveDirection.Right;
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
                        if (isGround)
                            Jump();
                    }
                    if (keyCode == KeyCode.Tab)
                    {
                        if (Managers.UIManager.CheckUIMountMargin(Defines.UIType.Inventory, Values.UI_MOUNT_MARGIN_INVENTORY))
                            Managers.UIManager.CreateUI(Defines.UIType.Inventory);
                    }
                    if (keyCode == KeyCode.Escape)
                    {
                        Managers.UIManager.CloseUI();
                    }
                    break;
                }
            case Defines.KeyInputType.Press:
                {
                    if (keyCode == KeyCode.A)
                        Move(Defines.MoveDirection.Left);
                    if (keyCode == KeyCode.D)
                        Move(Defines.MoveDirection.Right);
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
