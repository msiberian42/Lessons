using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected float speed => manager.GetSpeed();
    protected float lifetime => manager.GetLifetime();
    protected ObstaclesManager manager =>
        GameObject.FindGameObjectWithTag("Logic").GetComponent<ObstaclesManager>();
    protected AudioManager audioManager =>
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    protected float rotationSpeed;

    protected void MoveObstacle()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    protected void SetRotation(int minRotationSpeed, int maxRotationSpeed)
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        rotationSpeed *= (Random.Range(1, 3) == 2) ? -1 : 1;
    }
    protected void RotateObstacle()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
