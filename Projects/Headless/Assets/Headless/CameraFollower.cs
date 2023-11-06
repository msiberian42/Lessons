using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float smoothing = 1f;

    private Vector3 offset = new Vector3(0, 3, -10);
    private Transform player;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMVC.ControllerBase>().transform;
    }
    private void FixedUpdate()
    {
        if (player == null) return;

        Move();
    }
    private void Move()
    {
        var nextPos = Vector3.Lerp(transform.position, player.position + offset, Time.fixedDeltaTime * smoothing);

        transform.position = nextPos;
    }
}
