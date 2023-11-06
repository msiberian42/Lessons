using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelsList;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject backButton;
    [SerializeField] public TextMeshProUGUI moneyBalance;
    [SerializeField] private int cheatMoney;
    [SerializeField] private int cheatCount = 0;

    private void Start()
    {
        moneyBalance.text = SaveSystem.LoadData().moneyBalance.ToString();
    }
    public void OpenLevelsList()
    {
        mainMenu.SetActive(false);
        levelsList.SetActive(true);
        backButton.SetActive(true);
    }
    public void OpenShop()
    {
        mainMenu.SetActive(false);
        shop.SetActive(true);
        backButton.SetActive(true);
    }
    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        backButton.SetActive(true);
    }
    public void BackToMenu()
    {
        levelsList.SetActive(false);
        shop.SetActive(false);
        options.SetActive(false);
        backButton.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResetGame()
    {
        SaveSystem.SetData(money: 0, healthLvl: 0, cannonCapacityLvl: 0, cannonReloadLvl: 0, levelsPassed: 0);
        moneyBalance.text = SaveSystem.LoadData().moneyBalance.ToString();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Cheat()
    {
        cheatCount++;

        if (cheatCount == 7)
        {
            SaveSystem.SaveGame(moneyToAdd: cheatMoney);
            moneyBalance.text = SaveSystem.LoadData().moneyBalance.ToString();
            cheatCount = 0;
        }
    }
}
