using UnityEngine;
using PlayerMVC;

public class KeyboardPlayerController : ControllerBase
{
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode attackKey = KeyCode.LeftShift;

    private void Update()
    {
        GetInput();
    }
    private void GetInput()
    {
        //Debug.Log(IsGrounded());
        if (!IsGrounded() || state == State.Attacking || state == State.Death) return;

        if (!IsGrounded() && state == State.Jumping) return;

        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
            return;
        }
        if (Input.GetKeyDown(attackKey))
        {
            StartAttack();
            return;
        }

        CheckMovement();
        horizontalSpeed = Input.GetAxis("Horizontal");
    }
    private void CheckMovement()
    {
        float currentSpeed = Input.GetAxis("Horizontal");

        if (currentSpeed == horizontalSpeed) return;
        
        if (currentSpeed == 0)
        {
            state = State.Idle;
            OnStateChagned();
            return;
        }

        state = State.Moving;

        if (currentSpeed > 0)   
            direction = Direction.Right;
        else
            direction = Direction.Left;

        OnStateChagned();
    }
}
