using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startMoneyValue;
    [SerializeField] private int startIncome;
    public static int blueIncome { get; private set;}
    public static int redIncome { get; private set; }
    public static int blueMoneyValue { get; private set; }
    public static int redMoneyValue { get; private set; }

    private float timer;


    private void Awake()
    {
        blueIncome = startIncome;
        redIncome = startIncome;

        blueMoneyValue = startMoneyValue;
        redMoneyValue = startMoneyValue;
    }
    private void OnEnable()
    {
        SpawnFactory.OnUnitSpawnedEvent += OnUnitSpawned;
    }
    private void OnDisable()
    {
        SpawnFactory.OnUnitSpawnedEvent -= OnUnitSpawned;
    }
    private void Update()
    {
        SetIncomeTimer();
    }
    private void SetIncomeTimer()
    {
        if (timer >= 1)
        {
            timer -= 1;
            blueMoneyValue += blueIncome;
            redMoneyValue += redIncome;
            return;
        }

        timer += Time.deltaTime;
    }
    public static void IncreaseIncome(UnitColor color, int value)
    {
        if (color == UnitColor.Blue)
            blueIncome += value;
        else
            redIncome += value;
    }
    public static void DecreaseIncome(UnitColor color, int value)
    {
        if (color == UnitColor.Blue)
            blueIncome -= value;
        else
            redIncome -= value;
    }
    private void OnUnitSpawned(UnitConstructor unit)
    {
        if (unit.unitColor == UnitColor.Blue)
            blueMoneyValue -= Shop.unitPrice;
        else
            redMoneyValue -= Shop.unitPrice;
    }
    public static bool SpawnAllowed(UnitType type, UnitColor color)
    {
        if (color == UnitColor.Blue)
            return blueMoneyValue >= Shop.unitPrice;
        else
            return redMoneyValue >= Shop.unitPrice;
    }
}
