using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool playerIsAlive { get; private set; }
    public bool playerOnFire { get; private set; }
    [SerializeField] private float timeOfInvulnerability;
    [SerializeField] private int chanceOfFire;
    [SerializeField] private Animator cameraAnim;
    [SerializeField] private GameObject explosion;
    [SerializeField] private SceneDirector director;
    private Health health => GetComponent<Health>();    
    private Fuel fuel => GetComponent<Fuel>();    
    private Money money => GetComponent<Money>();
    private FireManager fire => GetComponent<FireManager>();
    protected DistanceCounter distance =>
        GameObject.FindGameObjectWithTag("Logic").GetComponent<DistanceCounter>();

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
        playerIsAlive = true;
        playerOnFire = false;
    }
    private void Update()
    {
        if (health.GetHealth() <= 0 || fuel.GetFuelLeftover() <= 0 || fire.fireLevel >= 100)
        {
            playerIsAlive = false;
            Instantiate(explosion, transform.position, Quaternion.identity);
            director.EndGame(money.money);
        }

        if (distance.distanceToFinish <= 0)
            director.PassLevel(money.money);

        if (fire.fireLevel <= 0)
            playerOnFire = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 && health.GetHealth() > 0)
        {
            cameraAnim.SetTrigger("ShakeCamera");
            StartCoroutine("GetInvunerable");
            health.TakeDamage();

            if (!playerOnFire)
                playerOnFire = (Random.Range(1, 101) <= chanceOfFire);
        }

        if (collision.gameObject.tag == "Coin")
            money.CollectCoin();

        if (collision.gameObject.tag == "Canister")
            fuel.CollectCanister();

        if (collision.gameObject.tag == "Exting")
            fire.CollectExting();

        if (collision.gameObject.tag == "ExtraHealth")
            health.AddHealth();
    }
    private IEnumerator GetInvunerable()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds (timeOfInvulnerability);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
