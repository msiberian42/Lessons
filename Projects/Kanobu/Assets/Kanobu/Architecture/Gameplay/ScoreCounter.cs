using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int startScore;
    public static event Action<UnitColor> OnGameOverEvent;

    public static int blueScore { get; private set; }
    public static int redScore { get; private set; }

    private void Start()
    {
        blueScore = startScore; 
        redScore = startScore;
    }
    private void Update()
    {
        if (blueScore <= 0) 
        {
            blueScore = 0;
            OnGameOver(UnitColor.Red);
        } 
        if (redScore <= 0)
        {
            redScore = 0;
            OnGameOver(UnitColor.Blue);
        } 
    }
    public static void DecreaseScore(UnitColor color)
    {
        if (color == UnitColor.Blue)
            blueScore--;
        if (color == UnitColor.Red)
            redScore--;
    }
    private void OnGameOver(UnitColor color)
    {
        OnGameOverEvent?.Invoke(color);
    }
}
