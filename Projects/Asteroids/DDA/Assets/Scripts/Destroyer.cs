using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
