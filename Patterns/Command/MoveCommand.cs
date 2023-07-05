using UnityEngine;

public abstract class MoveCommand
{
    protected Transform transform;
    protected float stepDistance;

    public MoveCommand(Transform transform, float stepDistance = 1f)
    {
        this.transform = transform;
        this.stepDistance = stepDistance;
    }

    public abstract void Execute();
    public abstract void Undo();

}
