using UnityEngine;
using System;

public class OldCharacterInputController : MonoBehaviour
{
    private IControllable _controllable;

    private void Awake()
    {
        _controllable = GetComponent<IControllable>();

        if (_controllable == null)
        {
            throw new Exception($"There is no IControllable on: {gameObject.name}");
        }
    }
    private void Update()
    {
        ReadMove();
        ReadJump();
    }
    private void ReadMove()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontal, 0f, 0f);

        _controllable.Move(direction);
    }
    private void ReadJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _controllable.Jump();
        }
    }
}
