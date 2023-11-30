using UnityEngine;

public class AbilityAdditionalDamage : AbilityUpgrade
{
    private int _additionalDamage;
    private DamageTypes _damageType;

    public AbilityAdditionalDamage(IAbility ability, int additionalDamage, DamageTypes damageType) : base(ability)
    {
        _additionalDamage = additionalDamage;
        _damageType = damageType;
    }

    public override void ApplyDamage(ICanBeDamaged canBeDamaged)
    {
        base.ApplyDamage(canBeDamaged);

        canBeDamaged.TakeDamage(_damageType, _additionalDamage);
    }
}
