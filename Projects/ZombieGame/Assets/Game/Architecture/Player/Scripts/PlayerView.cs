using MVC;
using UnityEngine;
using NaughtyAttributes;

public class PlayerView : ViewBase
{
    [SerializeField] private MainAnimationHandler mainAnim;
    [SerializeField] private HandsAnimationHandler handsAnim;

    private void Awake()
    {
        model = GetComponent<PlayerModel>();
        SetLookingDirection(LookingDirection.Down);
    }

    public override void SetLookingDirection(LookingDirection direction)
    {
        lookingDirection = direction;
        handsAnim.PlayIdleAnim(lookingDirection);
    }

    [Button]
    public override void OnPlayerIdleStatement()
    {
        mainAnim.PlayIdleAnim(lookingDirection);
    }
    [Button]
    public override void OnPlayerMoving()
    {
        mainAnim.PlayMovingAnim(lookingDirection);
    }
}
