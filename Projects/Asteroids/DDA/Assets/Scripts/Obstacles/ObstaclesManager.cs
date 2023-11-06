using System;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [Tooltip("Obstacles speed")]
    [SerializeField] private float speed;    
    [Tooltip("Obstacles lifetime")]
    [SerializeField] private float lifetime;

    [SerializeField] private GameObject box;
    [SerializeField] private GameObject destructionEffect;
    [SerializeField] private float boxSpawnChance;

    public float GetSpeed() { return speed; }    
    public float GetLifetime() { return lifetime; }

    public GameObject GetBox() { return box; }
    public GameObject GetDestructionEffect() { return destructionEffect; }
    public float GetBoxSpawnChance() { return boxSpawnChance; }

    [Header("Obstacles spawn positions by X")]
    [SerializeField] private float position1;
    [SerializeField] private float position2;
    [SerializeField] private float position3;
    [SerializeField] private float position4;

    public float GetPosition(int positionIndex)
    {
        switch (positionIndex)
        {
            case 1: return position1;
            case 2: return position2;
            case 3: return position3;
            case 4: return position4;
            default:
                throw new InvalidOperationException();
        }
    }
}
