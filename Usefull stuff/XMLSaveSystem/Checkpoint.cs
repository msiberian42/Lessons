using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameHelper gameHelper;

    private void Awake()
    {
        gameHelper = FindObjectOfType<GameHelper>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Character>())
        {
            gameHelper.Save();
        }
    }
}
