using MVC;
using System;
using UnityEngine;

public class PCInputHandler : MonoBehaviour, IInputHandler
{
    private KeyCode upKey = KeyCode.W;
    private KeyCode downKey = KeyCode.S;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;

    private Camera cam;
    private ControllerBase controller;

    public void Init(Camera cam, ControllerBase controller)
    {
        this.cam = cam;
        this.controller = controller;
    }
    private void Update()
    {
        GetMoveInput();
    }

    public float HorizontalSpeed()
    {
        return Input.GetAxis("Horizontal");
    }
    public float VerticalSpeed()
    {
        return Input.GetAxis("Vertical");
    }
    private void GetMoveInput()
    {
        if (Input.GetKeyDown(upKey))
        {
            controller.SetLookingDirectionToView(LookingDirection.Up);
        }
        if (Input.GetKeyDown(downKey))
        {
            controller.SetLookingDirectionToView(LookingDirection.Down);
        }
        if (Input.GetKeyDown(leftKey))
        {
            controller.SetLookingDirectionToView(LookingDirection.Left);
        }
        if (Input.GetKeyDown(rightKey))
        {
            controller.SetLookingDirectionToView(LookingDirection.Right);
        }
    }
    private void GetMouseInput()
    {

    }

    public Vector2 AimPos()
    {
        return (Vector2) cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
