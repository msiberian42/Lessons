using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public GameObject cube;

    private Storage storage;
    private GameData gameData;

    private void Start()
    {
        storage = new Storage();
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    private void Save()
    {
        gameData.position = cube.transform.position;
        gameData.rotation = cube.transform.rotation;

        storage.Save(gameData);
        Debug.Log("Game saved");
    }
    private void Load()
    {
        gameData = (GameData)storage.Load(new GameData());

        cube.transform.position = gameData.position;
        cube.transform.rotation = gameData.rotation;
        Debug.Log("Loaded speed: " + gameData.speed);
    }
}
