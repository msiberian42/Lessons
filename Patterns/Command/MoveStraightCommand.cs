using UnityEngine;

public class MoveStraightCommand : MoveCommand
{
    public MoveStraightCommand(Transform transform, float stepDistance = 1) : base(transform, stepDistance) {}

    public override void Execute()
    {
        transform.position += Vector3.right * stepDistance;
    }

    public override void Undo()
    {
        transform.position -= Vector3.right * stepDistance;
    }
}
