using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float speed;

    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;
    [SerializeField] private int damage;

    private float stopTime;
    [SerializeField] private float startStopTime;
    [SerializeField] private float normalSpeed;
    private Player player;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
    }

    private void Update()
    {
        if (stopTime <= 0)
        {

        }


        if (health <= 0)
        {
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
