using UnityEngine;

public class MainAnimationHandler : MonoBehaviour
{
    private Animator anim;

    private string currentState;

    private const string IDLE_DOWN = "Idle_Down";
    private const string IDLE_RIGHT = "Idle_Right";
    private const string IDLE_UP = "Idle_Up";
    private const string IDLE_LEFT = "Idle_Left";

    private const string WALKING_DOWN = "Walking_Down";
    private const string WALKING_RIGHT = "Walking_Right";
    private const string WALKING_UP = "Walking_Up";
    private const string WALKING_LEFT = "Walking_Left";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void PlayIdleAnim(LookingDirection lookingDirection)
    {
        string newState;

        switch (lookingDirection)
        {
            case LookingDirection.Down:
                newState = IDLE_DOWN;
                break;
            case LookingDirection.Right:
                newState = IDLE_RIGHT;
                break;
            case LookingDirection.Up:
                newState = IDLE_UP;
                break;
            default: // Left
                newState = IDLE_LEFT;
                break;
        }

        if (newState == currentState) return;

        currentState = newState;
        anim.Play(currentState);
    }
    public void PlayMovingAnim(LookingDirection lookingDirection)
    {
        string newState;

        switch (lookingDirection)
        {
            case LookingDirection.Down:
                newState = WALKING_DOWN;
                break;
            case LookingDirection.Right:
                newState = WALKING_RIGHT;
                break;
            case LookingDirection.Up:
                newState = WALKING_UP;
                break;
            default: // Left
                newState = WALKING_LEFT;
                break;
        }

        if (newState == currentState) return;

        currentState = newState;
        anim.Play(currentState);
    }
}
