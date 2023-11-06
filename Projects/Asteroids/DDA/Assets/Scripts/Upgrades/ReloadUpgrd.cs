using UnityEngine;
using UnityEngine.UI;

public class ReloadUpgrd : Upgrades
{
    [SerializeField] private Image[] reloadIcons;
    private int maxReloadLvl = 3;
    private int reloadLvl;

    private void Start()
    {
        reloadLvl = SaveSystem.LoadData().cannonReloadLvl;
        price *= 1 + reloadLvl;
        ShowPrice();
    }
    private void Update()
    {
        reloadLvl = SaveSystem.LoadData().cannonReloadLvl;
        upgrdOwned = reloadLvl >= maxReloadLvl;

        CheckUpgrade();

        for (int i = 0; i < maxReloadLvl; i++)
        {
            reloadIcons[i].enabled = i < reloadLvl;
        }
    }

    public void UpgradeReload()
    {
        BuyUpgrade();
        SaveSystem.SaveGame(reloadToAdd: 1);

        reloadLvl = SaveSystem.LoadData().cannonReloadLvl;
        price *= 1 + reloadLvl;
        ShowPrice();
    }
}
