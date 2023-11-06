using UnityEngine;
using UnityEngine.UI;

public class HealthUpgrade : Upgrades
{
    [SerializeField] private Image[] hearts;
    private int maxHealthLvl = 3;
    private int healthLevel;

    private void Start()
    {
        healthLevel = SaveSystem.LoadData().healthLvl;
        price *= 1 + healthLevel;
        ShowPrice();
    }
    private void Update()
    {
        healthLevel = SaveSystem.LoadData().healthLvl;
        upgrdOwned = healthLevel >= maxHealthLvl;

        CheckUpgrade();

        for (int i = 0; i < maxHealthLvl; i++)
        {
            hearts[i].enabled = i < healthLevel;
        }
    }

    public void UpgradeHealth()
    {
        BuyUpgrade();
        SaveSystem.SaveGame(healthToAdd: 1);

        healthLevel = SaveSystem.LoadData().healthLvl;
        price *= 1 + healthLevel;
        ShowPrice();
    }
}
