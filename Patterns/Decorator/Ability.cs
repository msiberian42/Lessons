public class Ability : IAbility
{
    private int _damage;
    private DamageTypes _damageType;

    public Ability(int damage, DamageTypes damageType)
    {
        _damage = damage;
        _damageType = damageType;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public DamageTypes GetDamageType()
    {
        return _damageType;
    }

    public void ApplyDamage(ICanBeDamaged canBeDamaged)
    {
        canBeDamaged.TakeDamage(_damageType, _damage);
    }
}
