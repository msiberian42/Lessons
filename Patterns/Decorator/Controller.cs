using UnityEngine;
using NaughtyAttributes;

public class Controller : MonoBehaviour
{
    [SerializeField] private UnitExample _unit;

    [Button]
    private void Test()
    {
        IAbility ability = new Ability(10, DamageTypes.Physical);
        ability = new AbilityAdditionalDamage(ability, 20, DamageTypes.Electic);

        ability.ApplyDamage(_unit);
    }
}
