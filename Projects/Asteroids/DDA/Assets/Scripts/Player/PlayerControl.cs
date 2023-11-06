using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.Mathematics;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Joystick joystick;
    private Cannon cannon => GetComponent<Cannon>();
    public Vector3 target { get; private set; }
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(6, 9, true);
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(10, 9, true);
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, -joystick.Horizontal * rotationSpeed);
        GetTouch();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(joystick.Horizontal * playerSpeed * Time.fixedDeltaTime, 0f);
    }
    private void GetTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            target = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began && target.y >= transform.position.y + 1f && target.y <= 3.5f)
            {
                cannon.Shoot();
            }
        }
    }
}
