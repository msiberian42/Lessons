using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SetData(int money, int healthLvl, int cannonCapacityLvl, int cannonReloadLvl, int levelsPassed)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(money, healthLvl, cannonCapacityLvl, cannonReloadLvl, levelsPassed);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
        }
        else
        {
            PlayerData data = new PlayerData(money: 0, healthLvl: 0, cannonCapacityLvl: 0, cannonReloadLvl: 0, levelsPassed: 0);
            return data;
        }
    }
    public static void SaveGame(int moneyToAdd = 0, int healthToAdd = 0, 
                                int capacityToAdd = 0, int reloadToAdd = 0, 
                                bool levelPassed = false)
    {
        PlayerData data = LoadData();

        int moneyBalance = data.moneyBalance + moneyToAdd;
        int healthLvl = data.healthLvl + healthToAdd;
        int cannonCapacityLvl = data.cannonCapacityLvl + capacityToAdd;
        int cannonReloadLvl = data.cannonReloadLvl + reloadToAdd;
        int levelsPassed = data.levelsPassed;

        if (levelPassed && data.levelsPassed < data.levelsNumber) levelsPassed++;

        SetData(moneyBalance, healthLvl, cannonCapacityLvl, cannonReloadLvl, levelsPassed);
    }
}
