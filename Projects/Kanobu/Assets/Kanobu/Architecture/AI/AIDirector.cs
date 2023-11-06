using System;
using System.Collections.Generic;
using UnityEngine;

public class AIDirector : MonoBehaviour
{
    [SerializeField] private UnitColor color;
    [SerializeField] private int mistakeChance;

    [SerializeField] private Transform leftSpawnPositions;
    [SerializeField] private Transform midSpawnPositions;
    [SerializeField] private Transform rightSpawnPositions;

    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;

    private UnitsAnalyser analyser;
    private List<Transform> spawnPositions;

    private void OnEnable()
    {
        analyser = new UnitsAnalyser(color);
        SpawnFactory.OnUnitSpawnedEvent += OnUnitSpawned;
        spawnPositions = new List<Transform>() { leftSpawnPositions, midSpawnPositions, rightSpawnPositions };
    }
    private void OnDisable()
    {
        SpawnFactory.OnUnitSpawnedEvent -= OnUnitSpawned;
    }
    private void Update()
    {
        if (color == UnitColor.None)
            Debug.LogError("Unit color must be set!");

        Invoke("SpawnUnit", UnityEngine.Random.Range(minDelay, maxDelay));
    }

    private void SpawnUnit()
    {
        UnitType type;
        Vector3 spawnPos;

        if (analyser.EnemyUnitsAreExist())
        {
            type = UnityEngine.Random.Range(1, 100) >= mistakeChance ? analyser.ChooseUnitType() : RandUnitType();
            spawnPos = UnityEngine.Random.Range(1, 100) >= mistakeChance ? FindSpawnPosition().position : RandSpawnPos();
        }
        else
        {
            type = RandUnitType();
            spawnPos = RandSpawnPos();
        }

        if (!Bank.SpawnAllowed(type, color)) return;
        SpawnFactory.SpawnUnit(type, color, spawnPos);
    }
    private void OnUnitSpawned(UnitConstructor unit)
    {
        analyser.AddUnit(unit);
    }
    private UnitType RandUnitType()
    {
        return (UnitType)UnityEngine.Random.Range(1, Enum.GetValues(typeof(UnitType)).Length);
    }
    private Vector3 RandSpawnPos()
    {
        return spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)].position;
    }
    private Transform FindSpawnPosition()
    {
        switch (analyser.FindPriorityLine()) 
        {
            case Line.Left:
                return leftSpawnPositions;
            case Line.Mid:
                return midSpawnPositions;
            default:
                return rightSpawnPositions;
        }

    }
}
