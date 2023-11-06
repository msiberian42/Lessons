using System;
using UnityEngine;

public class SceneDirector : MonoBehaviour
{
    public static GameMode gameMode { get; private set; }
    private static SceneDirector instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        gameMode = GameMode.PVE;
    }
    public static void ChangeGameMode()
    {
        if ((int)gameMode >= Enum.GetValues(typeof(GameMode)).Length - 1)
            gameMode = 0;
        else
            gameMode++;
    }
}
