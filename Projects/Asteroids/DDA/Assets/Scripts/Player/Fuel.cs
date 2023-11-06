using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [SerializeField] private int fuelLeftover;
    [SerializeField] private int fuelInCanister;
    [SerializeField] private float fuelConsumption;
    [SerializeField] private float refuelSpeed;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fuelBar;
    [SerializeField] private Animator fuelUI;

    private float fuelTimer;
    private bool isRefueling = false;
    private int requiredLeftover;
    protected SpawnTimer spawnTimer =>
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnTimer>();
    private void Start()
    {
        fuelLeftover = 100;
        fuelTimer = spawnTimer.GetTimeBtwSpawn() / fuelConsumption;
    }
    private void Update()
    {
        if (fuelLeftover < 0) fuelLeftover = 0;
        if (fuelLeftover > 100) fuelLeftover = 100;

        if (isRefueling)
            Refuel();
        else
            ConsumpFuel();

        slider.value = fuelLeftover;
        fuelBar.color = gradient.Evaluate(slider.normalizedValue);
    }

    public int GetFuelLeftover() { return fuelLeftover; }
    public void CollectCanister()
    {
        fuelUI.SetBool("isRefueling", true);
        requiredLeftover = fuelLeftover + fuelInCanister;
        isRefueling = true;
    }
    private void Refuel()
    {
        if (fuelTimer <= 0)
        {
            fuelTimer = spawnTimer.GetTimeBtwSpawn() / refuelSpeed;
            fuelLeftover++;
        }
        else
            fuelTimer -= Time.deltaTime;

        if (fuelLeftover == requiredLeftover || fuelLeftover >= 100)
        {
            isRefueling = false;
            fuelUI.SetBool("isRefueling", false);
        }
    }
    private void ConsumpFuel()
    {
        if (fuelTimer <= 0)
        {
            fuelTimer = spawnTimer.GetTimeBtwSpawn() / fuelConsumption;
            fuelLeftover--;
        }
        else
            fuelTimer -= Time.deltaTime;
    }
}
