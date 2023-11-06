using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlatformController : MonoBehaviour
{
    private Platform platform;
    private Collider2D coll;

    private void Awake()
    {
        platform = GetComponentInParent<Platform>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == platform.gameObject.layer)
        {
            Physics2D.IgnoreCollision(collision, coll);
            return;
        }
        
        CheckObjectPosition(collision);
    }

    private void CheckObjectPosition(Collider2D collision)
    {
        float objY = collision.transform.position.y + collision.offset.y - collision.bounds.size.y / 2;

        if (objY >= platform.transform.position.y)
        {
            platform.TurnOnCollision(collision);
        }
        else
        {
            platform.TurnOffCollision(collision);
        }
    }
    
}
