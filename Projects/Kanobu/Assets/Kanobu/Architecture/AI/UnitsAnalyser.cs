using System.Collections.Generic;
using UnityEngine;

public enum Line
{
    Left,
    Mid,
    Right
}

public class UnitsAnalyser
{
    private UnitColor color;
    private List<UnitConstructor> leftBlueUnits;
    private List<UnitConstructor> middleBlueUnits;
    private List<UnitConstructor> rightBlueUnits;
    private List<UnitConstructor> leftRedUnits;
    private List<UnitConstructor> middleRedUnits;
    private List<UnitConstructor> rightRedUnits;

    public UnitsAnalyser(UnitColor color)
    {
        this.color = color;

        leftBlueUnits = new List<UnitConstructor>();
        middleBlueUnits = new List<UnitConstructor>();
        rightBlueUnits = new List<UnitConstructor>();
        leftRedUnits = new List<UnitConstructor>();
        middleRedUnits = new List<UnitConstructor>();
        rightRedUnits = new List<UnitConstructor>();
    }
    public bool EnemyUnitsAreExist()
    {
        leftBlueUnits.RemoveAll(x => !x.isActiveAndEnabled);
        middleBlueUnits.RemoveAll(x => !x.isActiveAndEnabled);
        rightBlueUnits.RemoveAll(x => !x.isActiveAndEnabled);
        leftRedUnits.RemoveAll(x => !x.isActiveAndEnabled);
        middleRedUnits.RemoveAll(x => !x.isActiveAndEnabled);
        rightRedUnits.RemoveAll(x => !x.isActiveAndEnabled);

        if (color == UnitColor.Blue)
            return (leftRedUnits.Count + middleRedUnits.Count + rightRedUnits.Count > 0);

        else
            return (leftBlueUnits.Count + middleBlueUnits.Count + rightBlueUnits.Count > 0);
    }

    public void AddUnit(UnitConstructor unit)
    {
        switch (unit.unitColor)
        {
            case UnitColor.Blue:
                if (unit.transform.position.x < 0)
                    leftBlueUnits.Add(unit);
                else if (unit.transform.position.x == 0)
                    middleBlueUnits.Add(unit);
                else
                    rightBlueUnits.Add(unit);
                break;
            case UnitColor.Red:
                if (unit.transform.position.x < 0)
                    leftRedUnits.Add(unit);
                else if (unit.transform.position.x == 0)
                    middleRedUnits.Add(unit);
                else
                    rightRedUnits.Add(unit);
                break;
        }
    }

    public Line FindPriorityLine()
    {
        int leftPriority = leftRedUnits.Count - leftBlueUnits.Count;
        int midPriority = middleRedUnits.Count - middleBlueUnits.Count;
        int rightPriority = rightRedUnits.Count - rightBlueUnits.Count;

        if (color == UnitColor.Red)
        {
            leftPriority *= -1;
            midPriority *= -1;
            rightPriority *= -1;
        }

        if (leftPriority > midPriority)
        {
            if (leftPriority > rightPriority) return Line.Left;
            else return Line.Right;
        }
        else if (midPriority > rightPriority) return Line.Mid;
        else return Line.Right;
    }
    public UnitType ChooseUnitType()
    {
        UnitType enemyUnits;

        switch (FindPriorityLine())
        {
            case Line.Left:
                enemyUnits = CompareUnits(color == UnitColor.Blue ? leftRedUnits : leftBlueUnits);
                break;
            case Line.Mid:
                enemyUnits = CompareUnits(color == UnitColor.Blue ? middleRedUnits : middleBlueUnits);
                break;
            default:
                enemyUnits = CompareUnits(color == UnitColor.Blue ? rightRedUnits : rightBlueUnits);
                break;
        }

        return Refer.FindWhoStronger(enemyUnits);
    }
    private UnitType CompareUnits(List<UnitConstructor> units)
    {
        int rocks = units.FindAll(x => x.unitType == UnitType.Rock).Count;
        int papers = units.FindAll(x => x.unitType == UnitType.Paper).Count;
        int scissors = units.FindAll(x => x.unitType == UnitType.Scissors).Count;

        if (rocks > papers)
        {
            if (rocks > scissors) return UnitType.Rock;
            else return UnitType.Scissors;
        }
        else if (papers > scissors) return UnitType.Paper;
        else return UnitType.Scissors;
    }
}
