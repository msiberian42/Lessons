using UnityEngine;

public class SpyCar : BaseCar
{
    public void SetVisibility(bool enabled)
    {
        Debug.Log("SpyCar visibility enabled: " + enabled);
    }
}
