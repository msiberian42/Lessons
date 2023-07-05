using UnityEngine;

public class SingletonTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            GameManager.instance.Debug();

        if (Input.GetKeyDown(KeyCode.B))
            Bank.instance.Debug();
    }
}
