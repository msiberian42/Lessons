using System.Collections.Generic;
using UnityEngine;

namespace EnemyMVC
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ControllerBase : MonoBehaviour, IDamagable, IAttacker
    {
        #region FIELDS
        [SerializeField] protected ViewBase view;
        [SerializeField] protected ModelBase model;
        [SerializeField] protected LayerMask ground;
        [SerializeField] protected List<Transform> patrollingPoints = new List<Transform>();

        protected float moveSpeed;
        protected float aggroDistance;
        protected float attackDistance;

        protected float horizontalSpeed;
        protected Transform target;
        protected int currentPatrolPos = 0;

        public Direction direction { get; protected set; }
        public State state { get; protected set; }

        protected PlayerMVC.ControllerBase player;
        protected Rigidbody2D rb;
        protected Collider2D coll;
        protected const int groundLayer = 6;
        protected float deltaX = 0.5f;
        private float deltaY = 1.5f;
        #endregion

        #region MONOBEHS
        protected virtual void Awake()
        {
            direction = Direction.Left;
            state = State.Idle;
            OnStateChagned();

            player = FindAnyObjectByType<PlayerMVC.ControllerBase>();
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();
            GetModelData();
        }
        protected virtual void OnEnable()
        {
            model.OnValidateEvent += GetModelData;
        }
        protected virtual void OnDisable()
        {
            model.OnValidateEvent -= GetModelData;
        }
        protected virtual void FixedUpdate()
        {
            if (state == State.Patrolling || state == State.Chasing)
            {
                MoveEnemy();
            }
            if (state == State.Patrolling && (Mathf.Abs(transform.position.x - target.transform.position.x) <= deltaX))
            {
                SwitchPatrolPos();
            }
        }
        #endregion

        #region ATTACKING
        public void StartAttack()
        {
            rb.velocity = Vector2.zero;
            target = player.transform;
            state = State.Attacking;
            OnStateChagned();
        }
        public void OnAttackEnded()
        {


            if (DistanceToPlayer() <= attackDistance && player.state != PlayerMVC.State.Death)
            {
                StartAttack();
                return;
            }

            state = State.Idle;
            OnStateChagned();
        }
        #endregion

        #region PATROLLING
        protected void StartPatrolling()
        {
            target = patrollingPoints[currentPatrolPos].transform;
            state = State.Patrolling;
            OnStateChagned();
        }
        protected void SwitchPatrolPos()
        {
            if (currentPatrolPos == patrollingPoints.Count - 1)
                currentPatrolPos = 0;
            else
                currentPatrolPos++;

            target = patrollingPoints[currentPatrolPos];
        }
        #endregion

        protected void MoveEnemy()
        {
            rb.velocity = new Vector2(target.position.x - transform.position.x, 0f).normalized 
                * moveSpeed * Time.fixedDeltaTime;
        }

        protected void StartChasing()
        {
            target = player.transform;
            state = State.Chasing;
            OnStateChagned();
        }
        protected void SetDirection()
        {
            if (target == null) return;
            if (target.position.x > transform.position.x && direction == Direction.Left)
            {
                direction = Direction.Right;
                OnStateChagned();
                return;
            }
            if (target.position.x < transform.position.x && direction == Direction.Right)
            {
                direction = Direction.Left;
                OnStateChagned();
            }
        }
        protected bool IsGrounded()
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
        }
        protected float DistanceToPlayer()
        {
            return Vector2.Distance(transform.position, player.transform.position);
        }
        protected bool PlayerIsInAggroRange()
        {
            if (player.transform.position.y < transform.position.y - deltaY || player.transform.position.y > transform.position.y + deltaY)
                return false;

            if (DistanceToPlayer() > aggroDistance) return false;

            return true;
        }
        public void GetDamage()
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            coll.enabled = false;
            state = State.Death;
            OnStateChagned();
        }
        public Direction GetDirection()
        {
            return direction;
        }
        #region MVC
        protected void OnStateChagned()
        {
            view.OnStateChanged(state, direction);
        }
        private void GetModelData()
        {
            moveSpeed = model.moveSpeed;
            aggroDistance = model.aggroDistance;
            attackDistance = model.attackDistance;
        }
        #endregion

    }
}
