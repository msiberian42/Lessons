using UnityEngine;

public class FlyingCar : BaseCar
{
    public void Fly()
    {
        Debug.Log("FlyingCar is flying");
    }

    public override void Drive()
    {
        Fly();
    }
}
