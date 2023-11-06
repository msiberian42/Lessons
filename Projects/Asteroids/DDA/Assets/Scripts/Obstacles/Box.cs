using UnityEngine;

public class Box : Obstacle
{
    [SerializeField] private GameObject canister;
    [SerializeField] private float canisterSpawnChance;
    [SerializeField] private GameObject exting;
    [SerializeField] private float extingSpawnChance;
    [SerializeField] private GameObject extraHealth;
    [SerializeField] private float extraHealthSpawnChance;
    [SerializeField] private GameObject coin;
    
    private FireManager fireManager;
    private Fuel fuel;
    private Health health;
    private ObstaclesManager obstaclesManager;
    private GameObject player => GameObject.FindGameObjectWithTag("Player");

    private void Start()
    {
        obstaclesManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<ObstaclesManager>();
        fireManager = player.GetComponent<FireManager>();
        fuel = player.GetComponent<Fuel>();
        health = player.GetComponent<Health>();

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        MoveObstacle();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(obstaclesManager.GetDestructionEffect(), transform.position, Quaternion.identity);
            audioManager.PlayCrashSound();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 9)
        {
            Instantiate(obstaclesManager.GetDestructionEffect(), transform.position, Quaternion.identity);
            audioManager.PlayCrashSound();
            
            if (fireManager.fireLevel >= 40 && Random.Range(1f, 101f) <= extingSpawnChance)
                Instantiate(exting, transform.position, Quaternion.identity);
            else if (fuel.GetFuelLeftover() <= 60 && Random.Range(1f, 101f) <= canisterSpawnChance)
                Instantiate(canister, transform.position, Quaternion.identity);
            else if (health.GetHealth() <= 2 && Random.Range(1f, 101f) <= extraHealthSpawnChance)
                Instantiate(extraHealth, transform.position, Quaternion.identity);
            else
                Instantiate(coin, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

    }
}
