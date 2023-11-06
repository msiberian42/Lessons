using UnityEngine;

public class HandsAnimationHandler : MonoBehaviour
{
    private Animator anim;

    private string currentState;

    private const string EMPTY_IDLE_DOWN = "Empty_Idle_Down";
    private const string EMPTY_IDLE_RIGHT = "Empty_Idle_Right";
    private const string EMPTY_IDLE_UP = "Empty_Idle_Up";
    private const string EMPTY_IDLE_LEFT = "Empty_Idle_Left";

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
                newState = EMPTY_IDLE_DOWN;
                break;
            case LookingDirection.Right:
                newState = EMPTY_IDLE_RIGHT;
                break;
            case LookingDirection.Up:
                newState = EMPTY_IDLE_UP;
                break;
            default: // Left
                newState = EMPTY_IDLE_LEFT;
                break;
        }

        if (newState == currentState) return;

        currentState = newState;
        anim.Play(currentState);
    }
}
