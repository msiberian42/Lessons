using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] protected int price;
    [SerializeField] protected TextMeshProUGUI priceText;
    [SerializeField] protected GameObject priceTag;
    [SerializeField] protected GameObject ownedBlock;
    [SerializeField] protected GameObject moneyBlock;
    protected bool upgrdOwned;

    protected MainMenu menu => GameObject.FindGameObjectWithTag("Logic").GetComponent<MainMenu>();

    protected void CheckUpgrade()
    {
        ownedBlock.SetActive(upgrdOwned);
        moneyBlock.SetActive(SaveSystem.LoadData().moneyBalance < price && !upgrdOwned);
        GetComponent<Button>().enabled = (SaveSystem.LoadData().moneyBalance >= price && upgrdOwned == false);

        priceTag.SetActive(!upgrdOwned);
    }
    protected void ShowPrice()
    {
        priceText.text = price.ToString();
    }
    protected void BuyUpgrade()
    {
        SaveSystem.SaveGame(moneyToAdd: -price);
        menu.moneyBalance.text = SaveSystem.LoadData().moneyBalance.ToString();
    }


}
