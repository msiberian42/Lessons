using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private int bonusMoney;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private GameObject playerInterface;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject moneyCollected;
    
    [SerializeField] private GameObject gameOverText;

    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject bonusText;
    [SerializeField] private GameObject nextLvlButton;
    private void Start()
    {
        Time.timeScale = 1f;
        playerInterface.SetActive(true);

        bonusText.GetComponent<TextMeshProUGUI>().text = "Bonus:" + bonusMoney.ToString();
    }
    public void PassLevel(int money)
    {
        SaveSystem.SaveGame(moneyToAdd: money + bonusMoney, levelPassed: true);      
        StopRun(money);

        PlayerData data = SaveSystem.LoadData();

        winText.SetActive(true);
        bonusText.SetActive(true);
        nextLvlButton.SetActive(levelNumber < data.levelsNumber);
        gameOverScreen.GetComponent<Animator>().SetTrigger("LevelPassed");
    }
    public void EndGame(int money)
    {
        SaveSystem.SaveGame(money);
        StopRun(money);

        gameOverText.SetActive(true);
        gameOverScreen.GetComponent<Animator>().SetTrigger("GameOver");
    }
    private void StopRun(int money)
    {
        gameOverScreen.SetActive(true);
        moneyCollected.GetComponent<TextMeshProUGUI>().text = "Coins collected:" + money.ToString();

        player.SetActive(false);
        spawnManager.SetActive(false);
        playerInterface.SetActive(false);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextLevel()
    {
        int levelToLoad = SaveSystem.LoadData().levelsPassed + 1;
        SceneManager.LoadScene("Level_" + levelToLoad);
    }
}
