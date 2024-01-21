using UnityEngine;

кириллици
// кириллица
public class Destroyer : MonoBehaviour
{
    [SerializeField] private float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
