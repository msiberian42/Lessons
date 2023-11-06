using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private GameObject player;
    [SerializeField] private Slider distanceBar;
    
    public int distanceToFinish { get; private set; }
    private float distanceTimer;

    private SpawnTimer spawnTimer => spawnManager.GetComponent<SpawnTimer>();
    private PlayerManager playerManager => player.GetComponent<PlayerManager>();

    private void Start()
    {
        distanceToFinish = 100;
        distanceBar.value = distanceToFinish;
    }
    private void Update()
    {
        if (distanceToFinish < 0) distanceToFinish = 0;
        if (distanceToFinish > 100) distanceToFinish = 100;

        distanceBar.value = distanceToFinish;

        if (playerManager.playerIsAlive == true)
            CountDistance();     
    }
    private void CountDistance()
    {
        if (distanceTimer <= 0)
        {
            distanceTimer = spawnTimer.GetTimeBtwSpawn() / speed;
            distanceToFinish--;
        }
        else
            distanceTimer -= Time.deltaTime;
    }
}
