using UnityEngine;

public class SceneConfig : MonoBehaviour
{
    [SerializeField] private GameObject blueButtons;
    [SerializeField] private GameObject redButtons;
    [SerializeField] private GameObject redAI;
    [SerializeField] private GameObject blueAI;

    private void Awake()
    {
        GameMode gameMode = SceneDirector.gameMode;

        switch (gameMode)
        {
            case GameMode.PVP:
                blueButtons.SetActive(true);
                redButtons.SetActive(true);
                blueAI.SetActive(false);
                redAI.SetActive(false);
                break;
            case GameMode.EVE:
                blueButtons.SetActive(false);
                redButtons.SetActive(false);
                blueAI.SetActive(true);
                redAI.SetActive(true);
                break;
            default:
                blueButtons.SetActive(true);
                redButtons.SetActive(true);
                blueAI.SetActive(false);
                redAI.SetActive(true);
                break;
        }
    }
}
