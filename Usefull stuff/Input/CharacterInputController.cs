using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    private GameInput _gameInput;
    private IControllable _controllable;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _controllable = GetComponent<IControllable>();
        if (_controllable == null)
        {
            throw new Exception($"There is no IControllable on: {gameObject.name}");
        }
    }

    private void OnEnable()
    {
        _gameInput.Gameplay.Jump.performed += OnJumpPerformed;
    }
    private void OnDisable()
    {
        _gameInput.Gameplay.Jump.performed -= OnJumpPerformed;
    }
    private void Update()
    {
        ReadMovement();
    }
    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        _controllable.Jump();
    }
    private void ReadMovement()
    {
        var inputDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
        var direction = new Vector3(inputDirection.x, 0f, 0f);

        _controllable.Move(direction);
    }
}
