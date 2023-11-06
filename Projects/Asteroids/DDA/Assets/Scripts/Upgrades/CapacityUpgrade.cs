using UnityEngine;
using UnityEngine.UI;

public class CapacityUpgrade : Upgrades
{
    [SerializeField] private GameObject[] bombIcons;
    private int maxCapacityLvl = 3;
    private int capacityLevel;

    private void Start()
    {
        capacityLevel = SaveSystem.LoadData().cannonCapacityLvl;
        price *= 1 + capacityLevel;
    }
    private void Update()
    {
        capacityLevel = SaveSystem.LoadData().cannonCapacityLvl;
        upgrdOwned = capacityLevel >= maxCapacityLvl;

        ShowPrice();
        CheckUpgrade();

        for (int i = 0; i < maxCapacityLvl; i++)
        {
            bombIcons[i].SetActive(i < capacityLevel);
        }
    }

    public void UpgradeCapacity()
    {
        BuyUpgrade();
        SaveSystem.SaveGame(capacityToAdd: 1);

        capacityLevel = SaveSystem.LoadData().cannonCapacityLvl;
        price *= 1 + capacityLevel;
    }
}
