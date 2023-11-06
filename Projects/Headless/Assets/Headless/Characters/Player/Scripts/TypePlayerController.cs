using PlayerMVC;
using UnityEngine;

public class TypePlayerController : ControllerBase
{
    private InputFieldHandler input;

    protected override void Awake()
    {
        base.Awake();
        input = FindAnyObjectByType<InputFieldHandler>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        input.OnTextApplied += OnTextApplied;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        input.OnTextApplied -= OnTextApplied;
    }

    private void OnTextApplied(string text)
    {
        State state = this.state;
        Direction direction = this.direction;

        if (text == CommandsStorage.moveCommand && state != State.Moving)
        {
            state = State.Moving;
        }
        else if (text == CommandsStorage.stopCommand)
        {
            state = State.Idle;
        }
        else if (text == CommandsStorage.turnCommand)
        {
            direction = this.direction == Direction.Left ? Direction.Right : Direction.Left;
        }
        else if (text == CommandsStorage.jumpCommand)
        {
            state = State.Jumping;
        }
        else if (text == CommandsStorage.attackCommand)
        {
            state = State.Attacking;
        }
        else
            return;

        GetInput(state, direction);
    }

    private void GetInput(State state, Direction direction)
    {   
        if (!IsGrounded() || this.state == State.Attacking || this.state == State.Death) return;

        if (!IsGrounded() && this.state == State.Jumping) return;

        if (direction != this.direction)
        {
            this.direction = this.direction == Direction.Left ? Direction.Right : Direction.Left;
            horizontalSpeed = HorizontalSpeed();
            OnStateChagned();
            return;
        }

        if (state == this.state) return;

        switch (state)
        {
            case State.Moving:
                this.state = state;
                horizontalSpeed = HorizontalSpeed();
                OnStateChagned();
                break;
            case State.Jumping:
                Jump();
                break;
            case State.Attacking:
                StartAttack();
                break;
            default: // Idle
                horizontalSpeed = 0;
                this.state = State.Idle;
                OnStateChagned();
                break;
        }
    }
    private float HorizontalSpeed()
    {
        return direction == Direction.Left ? -1 : 1;
    }
}
