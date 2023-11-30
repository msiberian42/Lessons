using UnityEngine;

public class UnitExample : MonoBehaviour, ICanBeDamaged
{
    public void TakeDamage(DamageTypes type, int damage)
    {
        Debug.Log($"Type: {type}, damage : {damage}");
    }
}
