using System;
using UnityEngine;

public enum InputType
{
    PC,
    Android
}

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    public static Camera cam { get; private set; }

    [SerializeField] private InputType _inputType;
    public static InputType inputType { get; private set; }

    public static event Action<Vector3> OnPositionSetEvent;
    private InputHandlerBase inputHandler;

    private void Awake()
    {
        cam = _cam;
        inputType = _inputType;
        SetInputType();
    }

    private void SetInputType()
    {
        switch (inputType)
        {
            case InputType.PC:
                inputHandler = new PCInputHandler();
                break;
            case InputType.Android:
                inputHandler = new AndroidInputHandler();
                break;
        }
    }
    public static void SetPosition(Vector3 position)
    {
        OnPositionSetEvent?.Invoke(position);
    }
    private void Update()
    {
        inputHandler.HandleInput();
    }
}
