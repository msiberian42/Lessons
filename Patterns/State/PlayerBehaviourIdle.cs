using UnityEngine;

public class PlayerBehaviourIdle : IPlayerBehaviour
{
    public void Enter()
    {
        Debug.Log("Enter IDLE behaviour");
    }

    public void Exit()
    {
        Debug.Log("Exit IDLE behaviour");
    }

    public void Update()
    {
        Debug.Log("Update IDLE behaviour");
    }
}
