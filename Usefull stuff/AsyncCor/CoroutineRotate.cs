using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRotate : MonoBehaviour
{
    [SerializeField] private Transform[] obj;
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(LifeRoutine());
        }
    }

    private IEnumerator LifeRoutine()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            yield return StartCoroutine(RotateObjRoutine(obj[i], i + 1));
        }
    }

    private IEnumerator RotateObjRoutine(Transform o, float duration)
    {
        var timer = 0f;

        while (timer < 1f)
        {
            timer = Mathf.Min(timer + Time.deltaTime / duration, 1f);
            o.Rotate(Vector3.up, speed * Time.deltaTime);
            yield return null;
        }
    }
}
