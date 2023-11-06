using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject checkMark;
    private bool levelEnabled;
    void Start()
    {
        int levelsPassed = SaveSystem.LoadData().levelsPassed;
        levelEnabled = levelNumber <= levelsPassed || levelNumber == levelsPassed + 1;

        gameObject.GetComponent<Button>().enabled = levelEnabled;
        block.SetActive(!levelEnabled);

        checkMark.SetActive(levelNumber <= levelsPassed);
    }
    public void StartLevel()
    {
        SceneManager.LoadScene("Level_" + levelNumber);
    }

}
