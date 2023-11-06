using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject[] obstaclesToSpawn;
    [SerializeField] protected float spawnChance;
    protected int previousIndex;
    protected float spawnCoordinateX = 0f;
    protected bool obstSpawned = false;
    protected int rand;
    protected float spawnCoordinateY => 14f;
    protected ObstaclesManager manager =>
        GameObject.FindGameObjectWithTag("Logic").GetComponent<ObstaclesManager>();
    protected SpawnTimer spawnTimer =>
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnTimer>();

    protected void SpawnWithoutDelay(bool spawnInRandPos = false)
    {       
        if (spawnTimer.timer <= 0)
            SpawnRandomObst(spawnInRandPos);       
    }
    protected void SpawnWithDelay(bool spawnInRandPos)
    {
        if (spawnTimer.timer <= spawnTimer.GetTimeBtwSpawn() * 0.5f && spawnTimer.timer > 0 && obstSpawned == false)
        {
            SpawnRandomObst(spawnInRandPos);                      
            obstSpawned = true;
        }

        if (spawnTimer.timer <= 0)
            obstSpawned = false;       
    }
    protected void SpawnRandomObst(bool spawnInRandPos = false)
    {
        if (Random.Range(1f, 101f) <= spawnChance)
        {
            rand = Random.Range(0, obstaclesToSpawn.Length);
            if (obstaclesToSpawn.Length > 1)
            {
                if (rand == previousIndex)  // this condition prevents Spawner from spawn one Pattern twice in a row 
                    rand += (rand == 0) ? 1 : -1;
            }

            if (spawnInRandPos)
                spawnCoordinateX = manager.GetPosition(Random.Range(1, 5));

            Instantiate(obstaclesToSpawn[rand], new Vector3(spawnCoordinateX, spawnCoordinateY), transform.rotation);
            previousIndex = rand;
        }
    }
}
