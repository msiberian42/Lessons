using UnityEngine;

public class Canister : Obstacle
{
    private void Start()
    {
        SetRotation(4, 10);
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        MoveObstacle();
        RotateObstacle();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioManager.PlayRefuelSound();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
