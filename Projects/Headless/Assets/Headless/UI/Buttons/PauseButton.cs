using UnityEngine;

namespace UI
{
    public class PauseButton : ButtonBase
    {
        [SerializeField] private GameObject pauseScreen;
        
        protected override void OnButtonClick()
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
    }
}
