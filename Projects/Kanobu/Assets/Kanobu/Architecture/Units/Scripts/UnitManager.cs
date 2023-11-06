using UnityEngine;

public class UnitManager : MonoBehaviour
{
    // this class contains parameters that are qual for every Unit

    [SerializeField] private float _unitSpeed;
    public static float unitSpeed;

    [SerializeField] private float _maxY;
    public static float maxY;

    private void Awake()
    {
        unitSpeed = _unitSpeed;
        maxY = _maxY;
    }
}
