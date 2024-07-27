using UnityEngine;

public class PlayerController : MonoBehaviour, IKeyInput
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpPower = 20.0f;

    private Rigidbody2D rigidbody;

    private bool isGround = false;

    void Start()
    {
        Init();
    }

    void Init()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        Managers.InputManager.keyAction += KeyInput;
    }

    void Update()
    {

    }

    void Move(Defines.MoveDirection moveDir)
    {
        switch (moveDir)
        {
            case Defines.MoveDirection.Left:
                {
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    break;
                }
            case Defines.MoveDirection.Right:
                {
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    break;
                }
        }
    }

    void Jump()
    {
        isGround = false;
        rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
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
                        Managers.UIManager.CreateUI();
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
