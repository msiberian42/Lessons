using UnityEngine;

public class NetworkSpawnerFactory : ISpawnerFactory
{
    public IUnit SpawnUnit()
    {
        var go = new GameObject("Unit (NETWORK)");
        var unit = go.AddComponent<Unit>();
        go.AddComponent<NetworkBehaviour>();

        return unit;
    }
    public IInteractableObject SpawnInteractableObject()
    {
        var go = new GameObject("InteractableObject (NETWORK)");
        var unit = go.AddComponent<InteractableObject>();
        go.AddComponent<NetworkBehaviour>();

        return unit;
    }

    public IUnit SpawnPlayer()
    {
        var go = new GameObject("Player (NETWORK)");
        var unit = go.AddComponent<Unit>();
        go.AddComponent<Player>();
        go.AddComponent<NetworkBehaviour>();

        return unit;
    }
}
