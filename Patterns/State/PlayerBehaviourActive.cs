using UnityEngine;

public class PlayerBehaviourActive : IPlayerBehaviour
{
    public void Enter()
    {
        Debug.Log("Enter ACTIVE behaviour");
    }

    public void Exit()
    {
        Debug.Log("Exit ACTIVE behaviour");
    }

    public void Update()
    {
        Debug.Log("Update ACTIVE behaviour");
    }
}
