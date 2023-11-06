using System;
using UnityEngine;

public static class SpawnFactory
{
    public static event Action<UnitConstructor> OnUnitSpawnedEvent;

    public static void SpawnUnit(UnitType unitType, UnitColor unitColor, Vector3 spawnPosition)
    {
        if (unitColor == UnitColor.None)
            Debug.LogError("Unit color must be set!");

        if ((spawnPosition.y < 0) != (unitColor == UnitColor.Blue))
            return;

        if (!Bank.SpawnAllowed(unitType, unitColor))
            return;

        var obj = UnitPoolsManager.GetUnit(unitType, unitColor);
        obj.transform.position = spawnPosition;

        OnUnitSpawnedEvent?.Invoke(obj);
    }
}
