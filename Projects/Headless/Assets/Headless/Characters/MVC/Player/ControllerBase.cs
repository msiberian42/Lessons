using UnityEngine;

namespace PlayerMVC 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ControllerBase : MonoBehaviour, IDamagable, IAttacker
    {
        #region FIELDS
        [SerializeField] protected ViewBase view;
        [SerializeField] protected ModelBase model;
        [SerializeField] protected LayerMask ground;

        protected float horizontalSpeed;

        protected float moveSpeed;
        protected float jumpForceVertical;
        protected float jumpForceHorizontal;

        public Direction direction { get; protected set; }
        public State state { get; protected set; }

        protected Rigidbody2D rb;
        private BoxCollider2D coll;
        private GroundColliderHandler groundColl;
        private const int groundLayer = 6;
        private const int playerLayer = 7;
        private const int enemyLayer = 8;
        #endregion

        #region MONOBEHS
        protected virtual void Awake()
        {
            direction = Direction.Right;
            state = State.Idle;

            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<BoxCollider2D>();
            groundColl = GetComponentInChildren<GroundColliderHandler>();
            Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer);
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
        protected virtual void Start()
        {
            OnStateChagned();
        }
        protected virtual void FixedUpdate()
        {
            if (Time.timeScale == 0f) return;

            if (state == State.Moving && !IsGrounded())
            {
                state = State.Falling;
                OnStateChagned();
                horizontalSpeed = 0;
                return;
            }

            if (state == State.Moving)
            {
                MoveCharacter();
                return;
            }

            if (state == State.Jumping && rb.velocity.y < 0)
            {
                state = State.Falling; 
                OnStateChagned();
            }
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == groundLayer && state == State.Falling)
            {
                state = State.Idle;
                OnStateChagned();
            }
        }
        #endregion

        #region ATTACKING
        public void StartAttack()
        {
            rb.velocity = Vector2.zero;
            state = State.Attacking;
            OnStateChagned();
        }
        public void OnAttackEnded()
        {
            state = State.Idle;
            OnStateChagned();
        }
        #endregion

        protected void MoveCharacter()
        {
            rb.velocity = Vector2.right * moveSpeed * horizontalSpeed * Time.fixedDeltaTime;
            if (horizontalSpeed == 0)
            {
                state = State.Idle;
                OnStateChagned();
            }
        }
        protected void Jump()
        {
            state = State.Jumping;

            int xDirection = 1;
            if (direction == Direction.Left) xDirection = -1;

            rb.velocity = new Vector2(jumpForceHorizontal * xDirection, jumpForceVertical);
            OnStateChagned();
        }
        protected bool IsGrounded()
        {

            return groundColl.isGrounded;
        }

        #region MVC
        protected void OnStateChagned()
        {
            view.OnStateChanged(state, direction);
        }
        private void GetModelData()
        {
            moveSpeed = model.moveSpeed;
            jumpForceVertical = model.jumpForceVertical;
            jumpForceHorizontal = model.jumpForceHorizontal;
        }
        #endregion

        public void GetDamage()
        {
            state = State.Death;
            OnStateChagned();
        }

        public Direction GetDirection()
        {
            return direction;
        }
    }
}
