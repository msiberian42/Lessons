using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    [SerializeField] private Button btnStraight;
    [SerializeField] private Button btnDiagonal;
    [SerializeField] private Button btnUndo;
    [SerializeField] private Transform pivotTransform;
    [SerializeField] private float stepDistance;

    private List<MoveCommand> moveJournal = new List<MoveCommand> ();

    private void OnEnable()
    {
        btnStraight.onClick.AddListener(StepStraight);
        btnDiagonal.onClick.AddListener(StepDiagonal);
        btnUndo.onClick.AddListener(UndoLastMove);
    }

    private void OnDisable()
    {
        btnStraight.onClick.RemoveListener(StepStraight);
        btnDiagonal.onClick.RemoveListener(StepDiagonal);
        btnUndo.onClick.RemoveListener(UndoLastMove);
    }

    private void StepStraight()
    {
        var move = new MoveStraightCommand(pivotTransform, stepDistance);
        move.Execute();

        moveJournal.Add(move);

        Debug.Log("Step straight");
    }

    private void StepDiagonal()
    {
        var move = new MoveDiagonalCommand(pivotTransform, stepDistance);
        move.Execute();

        moveJournal.Add(move);

        Debug.Log("Step diagonal");
    }

    private void UndoLastMove()
    {
        if (moveJournal.Count > 0)
        {
            var lastMove = moveJournal.Last();

            lastMove.Undo();

            moveJournal.Remove(lastMove);

            Debug.Log("Undo");
        }
    }
}
