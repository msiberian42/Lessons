using UnityEngine;
using PlayerMVC;

public class Spikes : MonoBehaviour
{
    private const int groundLayer = 6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == groundLayer) return;

        ControllerBase player = collision.GetComponent<ControllerBase>();

        if (player != null)
        {
            player.GetDamage();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == groundLayer) return;

        ControllerBase player = collision.GetComponent<ControllerBase>();

        if (player != null)
        {
            player.GetDamage();
        }
    }
}
