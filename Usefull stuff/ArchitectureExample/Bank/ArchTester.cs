using System.Collections;
using UnityEngine;

public class ArchTester : MonoBehaviour
{
    private void Start()
    {
        Game.Run();
    }

    private void Update()
    {
        if (!Bank.isInitialized)
            return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            Bank.AddCoins(this, 5);
            Debug.Log("Coins added (5), " + Bank.coins);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Bank.Spend(this, 10);
            Debug.Log("Coins spent (10), " + Bank.coins);
        }
    }
}
