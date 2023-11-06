using TMPro;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    [SerializeField] private UnitColor color;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (color == UnitColor.Blue)
            text.text = $"Score: {ScoreCounter.blueScore}, Value: {Bank.blueMoneyValue}, Income: {Bank.blueIncome}";

        if (color == UnitColor.Red)
            text.text = $"Score: {ScoreCounter.redScore}, Value: {Bank.redMoneyValue}, Income: {Bank.redIncome}";
    }
}
