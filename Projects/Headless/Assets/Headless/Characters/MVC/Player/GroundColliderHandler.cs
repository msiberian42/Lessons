using UnityEngine;

public class GroundColliderHandler : MonoBehaviour
{
    public bool isGrounded { get; private set; }
    private int groundLayer = 6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            isGrounded = false;
        }
    }
}
