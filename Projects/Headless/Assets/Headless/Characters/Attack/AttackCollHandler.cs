using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackCollHandler : MonoBehaviour
{
    private AttackController controller;

    private void Awake()
    {
        controller = GetComponentInParent<AttackController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            controller.OnCollision(collision.gameObject.GetComponent<IDamagable>());
        }
    }
}
