using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int money { get; private set; }
    [SerializeField] private TextMeshProUGUI moneyCount;
    [SerializeField] private Animator[] coinUI;

    private void Start()
    {
        money = 0;
    }
    private void Update()
    {
        moneyCount.text = money.ToString();
    }

    public void CollectCoin()
    {
        money++;
        foreach (Animator item in coinUI)
        {
            item.SetTrigger("CoinCollected");
        }
    }
}
