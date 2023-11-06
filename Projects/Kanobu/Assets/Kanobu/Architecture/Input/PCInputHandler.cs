using UnityEngine;
using UnityEngine.EventSystems;

public class PCInputHandler : InputHandlerBase
{
    private UnitType unitType;
    private UnitColor unitColor;

    public override void HandleInput()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        GetMouseInput();
    }

    private void GetMouseInput()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        position = cam.ScreenToWorldPoint(Input.mousePosition);

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
