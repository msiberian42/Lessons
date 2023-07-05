using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagonalCommand : MoveCommand
{
    private Vector3 dirDiagonal = new Vector3(1f, -1f, 0f).normalized;

    public MoveDiagonalCommand(Transform transform, float stepDistance = 1) : base(transform, stepDistance) { }

    public override void Execute()
    {
        transform.position += dirDiagonal * stepDistance;
    }

    public override void Undo()
    {
        transform.position -= dirDiagonal * stepDistance;
    }
}
