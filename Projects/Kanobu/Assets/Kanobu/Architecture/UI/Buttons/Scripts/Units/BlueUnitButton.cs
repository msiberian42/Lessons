using UnityEngine;

public class BlueUnitButton : UnitButtonBase
{
    protected override void Start()
    {
        base.Start();
        unitColor = UnitColor.Blue;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
    }
    private void Update()
    {
        if (UnitButtonManager.blueUnitType != unitType)
            ReleaseButton();
    }
}
