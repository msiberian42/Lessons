using System.Collections;
using UnityEngine;

public class TesterMono : MonoBehaviour
{
    private Tester tester;

    private void Start()
    {
        this.tester = new Tester();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.tester.StartTestRoutine();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.tester.StopTestRoutine();
        }
    }
}
