using MVC;
using System;
using UnityEngine;

public interface IInputHandler
{
    void Init(Camera cam, ControllerBase controller);

    float HorizontalSpeed();
    float VerticalSpeed();

    Vector2 AimPos();
}
