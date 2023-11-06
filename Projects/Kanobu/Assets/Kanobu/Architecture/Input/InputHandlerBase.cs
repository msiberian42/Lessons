using UnityEngine;

public abstract class InputHandlerBase
{
    protected Camera cam;
    protected Vector3 position;

    public InputHandlerBase()
    {
        this.cam = InputManager.cam;
    }

    public abstract void HandleInput();
}
