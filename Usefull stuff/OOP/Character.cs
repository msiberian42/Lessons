using UnityEngine;

public class Character : MonoBehaviour, IControllable
{

    public void Run()
    {
        Debug.Log("Character: Run");
    }
    public void Walk()
    {
        Debug.Log("Character: Walk");
    }
    public void Move()
    {
        Run();
    }
}
