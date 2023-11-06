using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int rotationSpeed;
    private Vector3 target;
    private GameObject player;
    private Cannon cannon;
    private PlayerControl playerControl;
    private float speed;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private AudioSource audioSource => GetComponent<AudioSource>();
    private Vector3 direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cannon = player.GetComponent<Cannon>();
        playerControl = player.GetComponent<PlayerControl>();
        speed = cannon.GetBombSpeed();
        target = playerControl.target;

        direction = target - transform.position;
        direction.Normalize();
        rb.AddForce(direction * speed * 100);

        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.Play();

        Destroy(gameObject, 5);
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
