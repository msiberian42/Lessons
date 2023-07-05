using System.Collections;
using UnityEngine;

public class Tester
{
    private Coroutine routine;

    public void StartTestRoutine()
    {
        if (this.routine != null)
            return;
        
        this.routine = Coroutines.StartRoutine(this.LifeRoutine());
    }

    public void StopTestRoutine()
    {
        Coroutines.StopRoutine(this.routine);
        this.routine = null;
    }

    private IEnumerator LifeRoutine()
    {
        var timer = 0f;

        while (true)
        {
            Debug.Log($"LifeRoutine: {timer}");
            yield return new WaitForSeconds(1f);
            timer++;
        }
    }
}
