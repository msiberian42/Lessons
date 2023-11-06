using PlayerMVC;
using UnityEngine;
using System;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Collider2D coll;
    private IAttacker attacker;

    private Vector2 leftPos;

    private void Awake()
    {
        coll.enabled = false;
        leftPos = coll.transform.localPosition;
        attacker = GetComponentInParent<IAttacker>();
    }
    public void StartDamaging()
    {
        if (attacker.GetDirection() == Direction.Left)
            coll.transform.localPosition = new Vector2(leftPos.x, leftPos.y);
        else
            coll.transform.localPosition = new Vector2(-leftPos.x, leftPos.y);

        coll.enabled = true;
    }
    public void StopDamaging()
    {
        coll.enabled = false;
    }
    public void OnAttackEnded()
    {
        coll.enabled = false;
        attacker.OnAttackEnded();
    }
    public void OnCollision(IDamagable damagableObject)
    {
        damagableObject.GetDamage();
    }
}
