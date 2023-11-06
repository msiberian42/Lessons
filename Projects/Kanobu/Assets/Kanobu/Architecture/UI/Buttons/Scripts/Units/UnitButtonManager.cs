using UnityEngine;

public static class UnitButtonManager
{
    public static bool blueUnitChoosed { get; private set; }
    public static UnitType blueUnitType { get; private set; }

    public static bool redUnitChoosed { get; private set; }
    public static UnitType redUnitType { get; private set; }

    public static void ChooseUnit(UnitType unitType, UnitColor unitColor)
    {
        if (unitColor == UnitColor.None)
            Debug.LogError("Unit color must be set!");

        if (unitColor == UnitColor.Blue)
        {
            blueUnitType = unitType;
            blueUnitChoosed = true;
        }
        else
        {
            redUnitType = unitType;
            redUnitChoosed = true;
        }
    }
    public static void CancelChoice(UnitColor unitColor)
    {
        if (unitColor == UnitColor.Blue)
            blueUnitChoosed = false;
        
        else
            redUnitChoosed = false;
    }
}
