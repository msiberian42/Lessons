using UnityEngine;

public class LocalSpawnerFactory : ISpawnerFactory
{
    public IUnit SpawnUnit()
    {
        var go = new GameObject("Unit (LOCAL)");
        var unit =  go.AddComponent<Unit>();

        return unit;
    }
    public IInteractableObject SpawnInteractableObject()
    {
        var go = new GameObject("InteractableObject (LOCAL)");
        var unit = go.AddComponent<InteractableObject>();

        return unit;
    }

    public IUnit SpawnPlayer()
    {
        var go = new GameObject("Player (LOCAL)");
        var unit = go.AddComponent<Unit>();
        go.AddComponent<Player>();

        return unit;
    }
}
