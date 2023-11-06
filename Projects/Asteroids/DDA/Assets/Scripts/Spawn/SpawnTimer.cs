using System.Collections;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    [SerializeField] private float startTimeBtwSpawn = 1.5f;
    [SerializeField] private float decreaseTime = 0.007f;
    [SerializeField] private float minTime = 0.1f;

    public float timer { get; private set; }
    public float GetTimeBtwSpawn() { return startTimeBtwSpawn; }

    private void Update()
    {
        SetTimer();
    }
    private void SetTimer()
    {
        if (timer <= 0)
        {
            timer = startTimeBtwSpawn;

            if (startTimeBtwSpawn > minTime)
                startTimeBtwSpawn -= decreaseTime;
        }
        else
            timer -= Time.deltaTime;
    }
}
