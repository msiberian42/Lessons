using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncRotate : MonoBehaviour
{
    [SerializeField] private Transform[] obj;
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LifeAsync();
        }
    }

    private async void LifeAsync()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            var dur = await GetSpeed();

            await RotateAsync(obj[i], dur);
        }

        Debug.Log("Finish");
    }
    
    private async Task RotateAsync(Transform o, float duration)
    {
        var timer = 0f;

        while (timer < 1f)
        {
            timer = Mathf.Min(timer + Time.deltaTime / duration, 1f);
            o.Rotate(Vector3.up, speed * Time.deltaTime);

            await Task.Yield();
        }
    }

    private async Task<int> GetSpeed()
    {
        await Task.Delay(5 * 1000);

        Debug.Log("Got it");

        return Random.Range(1, 6);
    }
}
