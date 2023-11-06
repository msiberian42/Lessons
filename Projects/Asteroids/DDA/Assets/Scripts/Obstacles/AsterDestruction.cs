
public class AsterDestruction : Obstacle
{
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        MoveObstacle();
    }
}
