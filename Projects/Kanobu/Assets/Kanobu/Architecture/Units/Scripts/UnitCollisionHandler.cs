using UnityEngine;

public class UnitCollisionHandler : MonoBehaviour
{
    // adds automatically to Unit GameObject

    private UnitConstructor constructor;
    private float maxY;

    private void Awake()
    {
        constructor = GetComponent<UnitConstructor>();
        this.maxY = constructor.maxY;
    }
    private void Update()
    {
        if (Mathf.Abs(this.transform.position.y) >= maxY)
            Deactivate();
    }
    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Unit"))
        {
            UnitConstructor collUnit = collision.gameObject.GetComponent<UnitConstructor>();

            if (collUnit.unitColor == constructor.unitColor)
                return;

            UnitType collType = collUnit.unitType;

            if (collType == constructor.unitType)
                Deactivate();

            if (collType == Refer.FindWhoStronger(constructor.unitType))
                Deactivate();
        }
    }
}
