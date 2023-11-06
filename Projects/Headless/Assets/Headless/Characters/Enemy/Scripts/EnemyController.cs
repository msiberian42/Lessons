using UnityEngine;
using EnemyMVC;

public class EnemyController : ControllerBase
{
    [SerializeField] private Collider2D attackColl;
    private void Update()
    {
        if (state == State.Death) return;
        SetDirection();
        if (DistanceToPlayer() <= attackDistance && player.state != PlayerMVC.State.Death)
        {
            if (state != State.Attacking) StartAttack();
            return;
        }
        attackColl.enabled = false;
        if (PlayerIsInAggroRange() && player.state != PlayerMVC.State.Death)
        {
            if (state != State.Chasing) StartChasing();
            return;
        }
        if (patrollingPoints.Count > 0)
        {
            if (state != State.Patrolling) StartPatrolling();
            return;
        }

        if (state == State.Idle) return;
        target = null;
        state = State.Idle;
        OnStateChagned();
    }
}
