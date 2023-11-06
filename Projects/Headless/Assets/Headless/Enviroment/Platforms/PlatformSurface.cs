using UnityEngine;

public class PlatformSurface : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMVC.ControllerBase>())
            collision.gameObject.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMVC.ControllerBase>())
            collision.gameObject.transform.SetParent(null);
    }
}
