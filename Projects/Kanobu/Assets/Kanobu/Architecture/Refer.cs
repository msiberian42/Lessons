using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Refer
{
    public static UnitType FindWhoStronger(UnitType unit)
    {
        switch (unit)
        {
            case UnitType.Rock:
                return UnitType.Paper;
            case UnitType.Paper:
                return UnitType.Scissors;
            default:
                return UnitType.Rock;
        }
    }
    public static UnitType FindWhoWeaker(UnitType unit)
    {
        switch (unit)
        {
            case UnitType.Rock:
                return UnitType.Scissors;
            case UnitType.Paper:
                return UnitType.Rock;
            default:
                return UnitType.Paper;
        }
    }
}
