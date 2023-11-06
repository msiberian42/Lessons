using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private AudioSource[] gameSounds;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Money money;
    public void PauseGame()
    {
        Time.timeScale = 0f;

        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);

        foreach (AudioSource sound in gameSounds)
        {
            sound.Pause();
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);

        foreach (AudioSource sound in gameSounds)
        {
            sound.UnPause();
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
