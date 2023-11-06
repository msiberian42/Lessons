using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private int _unitPrice;
    public static int unitPrice { get; private set; }

    private void Update()
    {
        unitPrice = _unitPrice;
    }
}
