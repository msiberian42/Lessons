using UnityEngine;

public interface IAbility
{
    int GetDamage();
    DamageTypes GetDamageType();
    void ApplyDamage(ICanBeDamaged canBeDamaged);
}
