using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        ScoreCounter.OnGameOverEvent += OnGameOver;
    }
    private void OnDestroy()
    {
        ScoreCounter.OnGameOverEvent -= OnGameOver;
        Time.timeScale = 1;
    }

    private void OnGameOver(UnitColor color)
    {
        Time.timeScale = 0f;
        text.text = $"{color} wins!";
        gameOverScreen.SetActive(true);
    }
}
