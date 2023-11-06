using System.Drawing;
using UnityEngine;

public class SpawnCooldownTimer : MonoBehaviour
{
    [SerializeField] private float blueSpawnCooldown;
    [SerializeField] private float redSpawnCooldown;

    public static bool blueSpawnAllowed { get; private set; }
    public static bool redSpawnAllowed { get; private set; }

    public static SpawnCooldownTimer instance { get; private set; }

    private float blueTimer;
    private float redTimer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(gameObject);
    }
    private void OnEnable()
    {
        SpawnFactory.OnUnitSpawnedEvent += OnUnitSpawned;
    }
    private void OnDisable()
    {
        SpawnFactory.OnUnitSpawnedEvent -= OnUnitSpawned;
    }

    private void Start()
    {
        blueSpawnAllowed = true;
        redSpawnAllowed = true;
    }
    private void Update()
    {
        var deltaTime = Time.deltaTime;

        if (!blueSpawnAllowed)
        {
            blueTimer += deltaTime;

            if (blueTimer >= blueSpawnCooldown)
            {
                blueTimer -= blueSpawnCooldown;
                blueSpawnAllowed = true;
            }
        }

        if (!redSpawnAllowed)
        {
            redTimer += deltaTime;

            if (redTimer >= redSpawnCooldown)
            {
                redTimer -= redSpawnCooldown;
                redSpawnAllowed = true;
            }
        }
    }

    private void OnUnitSpawned(UnitConstructor unit)
    {
        if (unit.unitColor == UnitColor.None)
            Debug.LogError("Unit color must be set!");

        if (unit.unitColor == UnitColor.Blue)
            blueSpawnAllowed = false;

        else redSpawnAllowed = false;
    }
}
