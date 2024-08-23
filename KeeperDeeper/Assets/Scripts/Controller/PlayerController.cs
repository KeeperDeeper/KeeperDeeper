using DrillObject;
using UnityEngine;

/* 플레이어 컨트롤러
 * 플레이어 오브젝트에 직접 집어넣어서 
 */
public class PlayerController : MonoBehaviour, IKeyInput
{
    [SerializeField]
    private Drill drill;
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpPower = 5.0f;

    private Rigidbody2D rigidbody;

    private bool isGround = false;
    private int collidingGroundMount = 0;

    private Defines.MoveStatus moveStatus;
    private Animator animator;

    void Start()
    {
        Init();
    }

    void Update()
    {
        Move();
    }

    void Init()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        moveStatus = Defines.MoveStatus.Idle;

        animator = GetComponent<Animator>();

        Managers.InputManager.keyAction += KeyInput;
        Managers.DataManager.playerInventory.dropItemAction += DropItem;
    }

    public void SetFallingStateFalse()
    {
        moveStatus = Defines.MoveStatus.Idle;
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f);
        Debug.DrawRay(transform.position, Vector2.down, Color.red, 2f);
        if (hit.collider != null && hit.collider.CompareTag("GroundBlock"))
        {
            if (moveStatus == Defines.MoveStatus.Falling)
            {
                moveStatus = Defines.MoveStatus.FallingEnd;
            }
            isGround = true;
        }
        else
        {
            moveStatus = Defines.MoveStatus.Falling;
            isGround = false;
        }
    }

    private void Move()
    {
        switch (moveStatus)
        {
            case Defines.MoveStatus.Idle:
                {
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsFalling", false);
                    animator.SetBool("IsGround", true);
                    break;
                }
            case Defines.MoveStatus.MoveLeft:
                {
                    animator.SetBool("IsRunning", true);
                    animator.SetBool("IsFalling", false);
                    animator.SetBool("IsGround", true);
                    if (transform.localScale.x < 0)
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    break;
                }
            case Defines.MoveStatus.MoveRight:
                {
                    animator.SetBool("IsRunning", true);
                    animator.SetBool("IsFalling", false);
                    animator.SetBool("IsGround", true);
                    if (transform.localScale.x > 0)
                        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    break;
                }
            case Defines.MoveStatus.Falling:
                {
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsFalling", true);
                    animator.SetBool("IsGround", false);
                    animator.SetBool("Digging",  false);
                    drill.active = false;
                    drill.ActiveDrill();
                    break;
                }
            case Defines.MoveStatus.FallingEnd:
                {
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsFalling", true);
                    animator.SetBool("IsGround", true);
                    animator.SetBool("Digging", false);
                    break;
                }
        }
    }

    private void Jump()
    {
        isGround = false;
        rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void DiggingGround()
    {
        animator.SetBool("Digging", drill.active);
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
                    // 점프, 사용 안하니까 아예 다른 기능으로 변경 혹은 주석처리 바람
                    if (keyCode == KeyCode.Space)
                    {
                        if (Managers.GameManager.isBlockingUserInput)
                            return;

                        if (isGround)
                        {
                            moveStatus = Defines.MoveStatus.Idle;
                            drill.active = true;
                            drill.ActiveDrill();
                            DiggingGround(); //Jump();
                        }
                    }
                    // 인벤토리
                    if (keyCode == KeyCode.Tab)
                    {
                        if (Managers.GameManager.isBlockingUserInput)
                            return;

                        if (Managers.UIManager.CheckUIMountMargin(Defines.UIType.Inventory, Values.UI_MOUNT_MARGIN_INVENTORY))
                            Managers.UIManager.CreateUI(Defines.UIType.Inventory);
                    }
                    // Esc기능. 현재는 UI를 끄는 기능만 구현되어있음.
                    if (keyCode == KeyCode.Escape)
                    {
                        if (Managers.GameManager.isBlockingUserInput)
                            return;

                        Managers.UIManager.CloseUI();
                    }
                    // 상호작용. 대화중인 경우 대화를 진행하는 기능을, 그렇지 않다면 기타 상호작용을 함.
                    if (keyCode == KeyCode.E)
                    {
                        if (Managers.GameManager.isBlockingUserInput)
                        {
                            Managers.DialogueManager.inputWhileDialogue.Invoke();
                        }
                        else
                        {
                            Managers.GameManager.TryInteract();
                        }
                    }
                    break;
                }
            case Defines.KeyInputType.Press:
                {
                    if (keyCode == KeyCode.A)
                    {
                        if (isGround && moveStatus != Defines.MoveStatus.FallingEnd && !drill.active)
                            moveStatus = Defines.MoveStatus.MoveLeft;
                    }
                    if (keyCode == KeyCode.D)
                    {
                        if (isGround && moveStatus != Defines.MoveStatus.FallingEnd && !drill.active)
                            moveStatus = Defines.MoveStatus.MoveRight;
                    }
                    break;
                }
            case Defines.KeyInputType.Up:
                {
                    if (keyCode == KeyCode.Space)
                    {
                        if (isGround)
                        {
                            drill.active = false;
                            drill.ActiveDrill();
                            DiggingGround();
                        }
                    }
                    if (keyCode == KeyCode.A)
                    {
                        if (isGround)
                        {
                            moveStatus = Defines.MoveStatus.Idle;
                        }
                    }
                    if (keyCode == KeyCode.D)
                    {
                        if (isGround)
                        {
                            moveStatus = Defines.MoveStatus.Idle;
                        }
                    }
                    break;
                }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundBlock"))
        {
            collidingGroundMount += 1;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundBlock"))
        {
            if (moveStatus == Defines.MoveStatus.Falling)
            {
                moveStatus = Defines.MoveStatus.FallingEnd;
                return;
            }
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundBlock"))
        {
            collidingGroundMount -= 1;
            if (collidingGroundMount == 0)
            {
                moveStatus = Defines.MoveStatus.Falling;
                isGround = false;
            }
        }
    }
}
