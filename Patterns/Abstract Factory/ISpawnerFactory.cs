
public interface ISpawnerFactory
{
    IUnit SpawnUnit();
    IInteractableObject SpawnInteractableObject();
    IUnit SpawnPlayer();
}
