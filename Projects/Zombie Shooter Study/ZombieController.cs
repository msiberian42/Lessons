using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private float damageAmount = 5;

    private GameObject target;
    private Animator anim;
    private NavMeshAgent agent;


    private enum State { idle, wander, attack, chase, dead };
    State state = State.idle;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();     
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            KillZombie();
            return;
        }

        switch (state)
        {
            case State.idle:
                if (CanSeePlayer()) 
                    state = State.chase;
                else
                    state = State.wander;
                break;
            case State.wander:
                if (!agent.hasPath)
                {
                    float newX = this.transform.position.x + Random.Range(-5, 5);
                    float newZ = this.transform.position.z + Random.Range(-5, 5);
                    float newY = Terrain.activeTerrain.SampleHeight(new Vector3(newX, 0, newZ));

                    Vector3 dest = new Vector3(newX, newY, newZ);
                    agent.SetDestination(dest);
                    agent.stoppingDistance = 0;
                    agent.speed = walkingSpeed;

                    TurnOffTriggers();
                    anim.SetBool("isWalking", true);
                }

                if (CanSeePlayer())
                    state = State.chase;
                break;
            case State.chase:
                agent.SetDestination(target.transform.position);
                agent.stoppingDistance = 2;
                agent.speed = runningSpeed;

                TurnOffTriggers();
                anim.SetBool("isRunning", true);

                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
                {
                    state = State.attack;
                }

                if (ForgetPlayer())
                {
                    state = State.wander;
                    agent.ResetPath();
                }
                break;
            case State.attack:
                TurnOffTriggers();
                anim.SetBool("isAttacking", true);
                transform.LookAt(target.transform.position);

                if (DistanceToPlayer() > agent.stoppingDistance + 2)
                    state = State.chase;
                break;
            case State.dead:
                break;
        }
    }

    private void TurnOffTriggers()
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isDead", false);
    }

    public void KillZombie()
    {
        GameObject rd = Instantiate(ragdoll, transform.position, transform.rotation);
        rd.transform.Find("Hips").GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 10000);
        Destroy(gameObject);
    }
    public void DamagePlayer()
    {
        target.GetComponent<FPController>().TakeHit(damageAmount);
    }

    private bool CanSeePlayer()
    {
        return (DistanceToPlayer() < 10);
    }
    private bool ForgetPlayer()
    {
        return DistanceToPlayer() >= 10;
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(target.transform.position, transform.position);
    }
}
