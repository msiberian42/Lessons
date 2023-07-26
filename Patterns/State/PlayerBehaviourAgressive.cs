using UnityEngine;

public class PlayerBehaviourAgressive : IPlayerBehaviour
{
    public void Enter()
    {
        Debug.Log("Enter AGRESSIVE behaviour");
    }

    public void Exit()
    {
        Debug.Log("Exit AGRESSIVE behaviour");
    }

    public void Update()
    {
        Debug.Log("Update AGRESSIVE behaviour");
    }
}
