using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float endY;
    [SerializeField] private float startY;
    [SerializeField] private SpawnTimer spawnTimer;
    private float startZ = 5f;

    private void Update()
    {
        transform.Translate(Vector2.down * speed / spawnTimer.GetTimeBtwSpawn() * Time.deltaTime);

        if (transform.position.y <= endY)
            transform.position = new Vector3(transform.position.x, startY, startZ);
    }
}
