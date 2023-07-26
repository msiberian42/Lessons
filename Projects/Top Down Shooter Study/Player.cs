using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ControlType controlType;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private GameObject face;

    private enum ControlType { PC, Android}

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        joystick.gameObject.SetActive(controlType == ControlType.Android);

        if (controlType == ControlType.PC)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else if (controlType == ControlType.Android)
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }

        animator.SetBool("isRunning", moveInput != Vector2.zero);

        moveVelocity = moveInput.normalized * speed;

        if (!facingRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput.x < 0)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = face.transform.localScale;
        scaler.x *= -1;
        face.transform.localScale = scaler;
    }
}
