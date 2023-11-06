using MVC;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : ControllerBase
{
    [SerializeField] private InputManager inputManager;
    private Rigidbody2D rb;
    private IInputHandler inputHandler;

    private float horizontalSpeed;
    private float verticalSpeed;
    private Vector2 aimPos;

    private void Awake()
    {
        view = GetComponent<ViewBase>();
        model = GetComponent<ModelBase>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        moveSpeed = model.moveSpeed;
        inputHandler = inputManager.inputHandler;
    }

    private void Update()
    {
        GetInput();

        if (horizontalSpeed != 0 || verticalSpeed != 0)
            view.OnPlayerMoving();
        else
            view.OnPlayerIdleStatement();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    private void GetInput()
    {
        horizontalSpeed = inputHandler.HorizontalSpeed();
        verticalSpeed = inputHandler.VerticalSpeed();

        if (aimPos != inputHandler.AimPos())
        {
            aimPos = inputHandler.AimPos();
            SetLookingDirectionToView(LookingDirecionByAim());
        }
    }
    protected override void MoveCharacter()
    {
        rb.velocity = new Vector2 (horizontalSpeed, verticalSpeed) * moveSpeed * Time.fixedDeltaTime;
    }
    private LookingDirection LookingDirecionByAim()
    {
        float playerX = transform.position.x;
        float playerY = transform.position.y;
        float aimX = aimPos.x;
        float aimY = aimPos.y;

        float deltaX = Mathf.Abs(playerX - aimX);
        float deltaY = Mathf.Abs(playerY - aimY);

        LookingDirection lookingDirection;

        if (deltaX > deltaY)
        {
            if (playerX > aimX)
                lookingDirection = LookingDirection.Left;
            else
                lookingDirection = LookingDirection.Right;
        }
        else
        {
            if (playerY > aimY)
                lookingDirection = LookingDirection.Down;
            else
                lookingDirection = LookingDirection.Up;
        }

        return lookingDirection;
    }
}
