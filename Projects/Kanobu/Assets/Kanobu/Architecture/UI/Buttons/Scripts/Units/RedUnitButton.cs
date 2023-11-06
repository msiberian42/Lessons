using UnityEngine;

public class RedUnitButton : UnitButtonBase
{
    protected override void Start()
    {
        base.Start();
        unitColor = UnitColor.Red;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
    }
    private void Update()
    {
        if (UnitButtonManager.redUnitType != unitType)
            ReleaseButton();
    }
}
