using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class RestartButton : ButtonBase
    {
        protected override void OnButtonClick()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
