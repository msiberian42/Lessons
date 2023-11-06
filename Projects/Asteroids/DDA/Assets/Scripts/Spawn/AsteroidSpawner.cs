using UnityEngine;

public class AsteroidSpawner : Spawner
{
    [SerializeField] private float additionSpawnChance;

    private void Update()
    {
        //Asteroid spawn rate always needs to be 100
        if (spawnChance != 100)
            spawnChance = 100;
        
        SpawnWithoutDelay();

        if (Random.Range(1f, 101f) <= additionSpawnChance)
            SpawnWithDelay(false);
    }
}
