using System.Collections;
using UnityEngine;

public class ArchTester : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        Game.Run();
        Game.OnGameInitializedEvent += OnGameInitialized;
    }

    private void OnGameInitialized()
    {
        Game.OnGameInitializedEvent -= OnGameInitialized;
        var playerInteractor = Game.GetInteractor<PlayerInteractor>();
        this.player = playerInteractor.player;
    }

    private void Update()
    {
        if (!Bank.isInitialized)
            return;

        if (this.player == null)
            return;

        Debug.Log($"Player position: {this.player.transform.position}");

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
