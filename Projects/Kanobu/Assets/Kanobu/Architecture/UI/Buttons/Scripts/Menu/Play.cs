using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Exit);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(Exit);
    }
    private void Exit()
    {
        SceneManager.LoadScene("Game");
    }
}
