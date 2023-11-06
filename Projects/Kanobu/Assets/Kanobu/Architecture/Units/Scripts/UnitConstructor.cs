using UnityEngine;

public class UnitConstructor : MonoBehaviour
{
    // add this script to each Unit GameObject
    // this class contains parameters that are unique for each Unit

    [SerializeField] private UnitType _unitType;
    [SerializeField] private UnitColor _unitColor;
    public UnitType unitType => _unitType;
    public UnitColor unitColor => _unitColor;

    public float speed { get; private set; }
    public float maxY { get; private set; }

    private void Awake()
    {
        if (unitColor == UnitColor.None)
            Debug.LogError("Unit color must be set!");

        this.speed = UnitManager.unitSpeed;
        this.maxY = UnitManager.maxY;

        this.gameObject.AddComponent<UnitMovement>();
        this.gameObject.AddComponent<UnitCollisionHandler>();
    }
}
