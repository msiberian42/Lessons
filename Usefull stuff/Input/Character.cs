using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _checkGroundRadius = 0.4f;
    private CharacterController _controller;
    private Vector3 _moveDirection;
    private float _velocity;
    private bool _isGrounded;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        _isGrounded = IsOnTheGround();

        if (_isGrounded && _velocity < 0)
        {
            _velocity = -2;
        }

        MoveInternal();
        DoGravity();
    }
    public void Move(Vector3 direction)
    {
        _moveDirection = direction;

        MoveInternal();
    }
    private void MoveInternal()
    {
        _controller.Move(_moveDirection * _speed * Time.fixedDeltaTime);
    }
    private void DoGravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;

        _controller.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
    }
    private bool IsOnTheGround()
    {
        bool result = Physics.CheckSphere(_groundCheckerPivot.position, _checkGroundRadius, _groundMask);
        return result;
    }
    public void Jump()
    {
        if (_isGrounded)
        {
            _velocity = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }
    }
}
