using UnityEngine;

public class MoneyPoint : MonoBehaviour
{
    [SerializeField] private int incomePerSecond;

    private UnitColor color = UnitColor.None;
    private bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            UnitColor unitColor = collision.GetComponent<UnitConstructor>().unitColor;

            if (color == unitColor) return;

            color = unitColor;

            if (!isActive)
            {
                isActive = true;
                Bank.IncreaseIncome(color, incomePerSecond);
            }
            else
                ChangeColor(color);
        }
    }
    private void ChangeColor(UnitColor color)
    {
        if (color == UnitColor.None)
            Debug.LogError("Unit color must be set!");

        Bank.IncreaseIncome(color, incomePerSecond);
        Bank.DecreaseIncome((color == UnitColor.Blue ? UnitColor.Red : UnitColor.Blue), incomePerSecond);
    }
}
