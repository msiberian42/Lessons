[System.Serializable]
public class PlayerData
{
    public int moneyBalance;
    public int healthLvl;
    public int cannonCapacityLvl;
    public int cannonReloadLvl;
    public int levelsPassed;
    public int levelsNumber = 6;

    public PlayerData(int money, int healthLvl, int cannonCapacityLvl, int cannonReloadLvl, int levelsPassed)
    {
        moneyBalance = money;
        if (moneyBalance < 0) moneyBalance = 0;

        this.healthLvl = healthLvl;
        if (this.healthLvl < 0) this.healthLvl = 0;
        if (this.healthLvl > 3) this.healthLvl = 3;        
        
        this.cannonCapacityLvl = cannonCapacityLvl;
        if (this.cannonCapacityLvl < 0) this.cannonCapacityLvl = 0;
        if (this.cannonCapacityLvl > 3) this.cannonCapacityLvl = 3;        
        
        this.cannonReloadLvl = cannonReloadLvl;
        if (this.cannonReloadLvl < 0) this.cannonReloadLvl = 0;
        if (this.cannonReloadLvl > 3) this.cannonReloadLvl = 3;

        this.levelsPassed = levelsPassed;
        if (this.levelsPassed < 0) this.levelsPassed = 0;
        if (this.levelsPassed > levelsNumber) this.levelsPassed = levelsNumber;
    }
}
