using UnityEngine;

public class Coin : Obstacle
{
    void Start()
    {
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
            audioManager.PlayCoinSound();
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}

