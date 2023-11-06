using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
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
        Application.Quit();
    }
}
