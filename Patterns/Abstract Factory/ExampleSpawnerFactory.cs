using UnityEngine;

public class ExampleSpawnerFactory : MonoBehaviour
{
    private ISpawnerFactory factory;

    private void Start()
    {
        SetModeLocal();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetModeLocal();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetModeNetwork();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            factory.SpawnUnit();

        if (Input.GetKeyDown(KeyCode.Alpha4))
            factory.SpawnInteractableObject();

        if (Input.GetKeyDown(KeyCode.Alpha5))
            factory.SpawnPlayer();
    }

    private void SetModeLocal()
    {
        factory = new LocalSpawnerFactory();

        Debug.Log("Local mode enabled");
    }

    private void SetModeNetwork()
    {
        factory = new NetworkSpawnerFactory();

        Debug.Log("Network mode enabled");
    }
}
