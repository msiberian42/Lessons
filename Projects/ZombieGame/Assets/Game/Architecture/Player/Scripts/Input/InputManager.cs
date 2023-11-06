using MVC;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ControllerBase controller;
    public IInputHandler inputHandler {  get; private set; }

    private void Awake()
    {
        inputHandler = gameObject.AddComponent<PCInputHandler>();
        inputHandler.Init(mainCamera, controller);
    }
}
