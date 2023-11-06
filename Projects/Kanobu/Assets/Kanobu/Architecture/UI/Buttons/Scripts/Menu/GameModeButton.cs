using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameModeButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeGameMode);
        text.text = SceneDirector.gameMode.ToString();
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(ChangeGameMode);
    }
    private void ChangeGameMode()
    {
        SceneDirector.ChangeGameMode();
        text.text = SceneDirector.gameMode.ToString();
    }
}
