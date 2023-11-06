using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPoolsManager : MonoBehaviour
{
    [SerializeField] private int poolLenght;

    [SerializeField] private UnitConstructor blueRock;
    [SerializeField] private UnitConstructor bluePaper;
    [SerializeField] private UnitConstructor blueScissors;
    [SerializeField] private UnitConstructor redRock;
    [SerializeField] private UnitConstructor redPaper;
    [SerializeField] private UnitConstructor redScissors;

    private static Pool<UnitConstructor> blueRockPool;
    private static Pool<UnitConstructor> bluePaperPool;
    private static Pool<UnitConstructor> blueScissorsPool;
    private static Pool<UnitConstructor> redRockPool;
    private static Pool<UnitConstructor> redPaperPool;
    private static Pool<UnitConstructor> redScissorsPool;

    private void Start()
    {
        blueRockPool = new Pool<UnitConstructor> (blueRock, poolLenght);
        bluePaperPool = new Pool<UnitConstructor>(bluePaper, poolLenght);
        blueScissorsPool = new Pool<UnitConstructor>(blueScissors, poolLenght);
        redRockPool = new Pool<UnitConstructor>(redRock, poolLenght);
        redPaperPool = new Pool<UnitConstructor>(redPaper, poolLenght);
        redScissorsPool = new Pool<UnitConstructor>(redScissors, poolLenght);
    }

    public static UnitConstructor GetUnit(UnitType unitType, UnitColor unitColor)
    {
        if (unitColor == UnitColor.None)
            Debug.LogError("Unit color must be set!");

        if (unitType == UnitType.Rock)
            return unitColor == UnitColor.Blue?
                blueRockPool.GetObject() : redRockPool.GetObject();

        if (unitType == UnitType.Paper)
            return unitColor == UnitColor.Blue?
                bluePaperPool.GetObject() : redPaperPool.GetObject();

        return unitColor == UnitColor.Blue ?
            blueScissorsPool.GetObject() : redScissorsPool.GetObject();
    }
}
