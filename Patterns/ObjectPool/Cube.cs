using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;

    private void OnEnable()
    {
        this.StartCoroutine("LifeRoutine");
    }
    private void OnDisable()
    {
        this.StopCoroutine("LifeRoutine");
    }
    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(this.lifetime);

        this.Deactivate();
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
