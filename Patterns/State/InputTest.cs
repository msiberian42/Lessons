using UnityEngine;

public class InputTest : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            this.player.SetBehaviourAgressive();

        if (Input.GetKeyDown(KeyCode.I))
            this.player.SetBehaviourIdle();

        if (Input.GetKeyDown(KeyCode.C))
            this.player.SetBehaviourActive();
    }
}
