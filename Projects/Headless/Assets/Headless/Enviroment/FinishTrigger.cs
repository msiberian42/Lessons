using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject finishScreen;

    private PlayerMVC.ControllerBase player;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMVC.ControllerBase>();
        finishScreen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            FinishLevel();
        }
    }
    private void FinishLevel()
    {
        player.gameObject.SetActive(false);

        finishScreen.SetActive(true);
    }
}
