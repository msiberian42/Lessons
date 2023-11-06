using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    // adds automatically to Unit GameObject

    private UnitConstructor constructor;
    private float speed;
    private bool moveUp;

    private void Awake()
    {
        constructor = GetComponent<UnitConstructor>();
        speed = constructor.speed;
        moveUp = constructor.unitColor == UnitColor.Blue;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position += (moveUp ? Vector3.up : Vector3.down) * speed * Time.deltaTime;
    }
}
