using UnityEngine;

public static class UnitExtensions
{
    public static Unit SetName(this Unit unit, string name)
    {
        unit.Name = name;
        return unit;
    }
    public static Unit SetDescription(this Unit unit, string description)
    {
        unit.Description = description;
        return unit;
    }
    public static Unit WithWeapon(this Unit unit, Weapon weapon)
    {
        unit.weapon = weapon;
        return unit;
    }
    public static Unit SetBaseDamage(this Unit unit, int baseDamage, UnitMainConfig config)
    {
        var clampedDamage = Mathf.Clamp(baseDamage, 0, config.MaxDamage);

        unit.BaseDamage = clampedDamage;
        return unit;
    }
}
