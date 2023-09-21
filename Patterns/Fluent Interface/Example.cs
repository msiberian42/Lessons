using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        var config = new UnitMainConfig(100);

        var unit1 = new Unit()
            .SetName("Unit 1")
            .SetDescription("1 Desc")
            .SetBaseDamage(1000, config)
            .WithWeapon(new Weapon("Car"));

        var unit2 = new Unit()
            .SetName("Unit 2")
            .SetBaseDamage(-100, config)
            .WithWeapon(new Weapon("Mouse"));

        Debug.Log(unit1);
        Debug.Log(unit2);
    }
}
