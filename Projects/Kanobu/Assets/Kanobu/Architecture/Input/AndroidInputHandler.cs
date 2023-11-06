using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidInputHandler : InputHandlerBase
{
    private UnitType unitType;
    private UnitColor unitColor;

    public override void HandleInput()
    {
        if (Input.touchCount <= 0) return;

        GetTouchInput();
    }

    private void GetTouchInput()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        position = cam.ScreenToWorldPoint(Input.GetTouch(0).position);

        if (position.y < 0 && UnitButtonManager.blueUnitChoosed)
        {
            unitType = UnitButtonManager.blueUnitType;
            unitColor = UnitColor.Blue;
        }
        else if (position.y > 0 && UnitButtonManager.redUnitChoosed)
        {
            unitType = UnitButtonManager.redUnitType;
            unitColor = UnitColor.Red;
        }
        else
            return;

        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);

        if (hit.collider && hit.collider.CompareTag("SpawnPoint"))
            SpawnFactory.SpawnUnit(unitType, unitColor, hit.collider.transform.position);

        InputManager.SetPosition(position);
    }
}
