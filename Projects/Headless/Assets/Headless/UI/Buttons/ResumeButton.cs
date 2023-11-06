using UnityEngine;

namespace UI
{
    public class ResumeButton : ButtonBase
    {
        [SerializeField] private GameObject pauseScreen;

        protected override void OnButtonClick()
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
    }
}
