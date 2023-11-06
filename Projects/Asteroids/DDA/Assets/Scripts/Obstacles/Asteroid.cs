
using UnityEngine;

public class Asteroid : Obstacle
{
    private ObstaclesManager obstaclesManager;

    private void Start()
    {
        obstaclesManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<ObstaclesManager>();

        if (Random.Range(1f, 101f) <= obstaclesManager.GetBoxSpawnChance()) 
        {
            Instantiate(obstaclesManager.GetBox(), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
          
        SetRotation(50, 200);
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        MoveObstacle();
        RotateObstacle();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == 9)
        {
            Instantiate(obstaclesManager.GetDestructionEffect(), transform.position, Quaternion.identity);
            audioManager.PlayCrashSound();
            Destroy(gameObject);
        }
    }
}
