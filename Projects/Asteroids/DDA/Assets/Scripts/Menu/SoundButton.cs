using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TextMeshProUGUI soundText;
    
    private void Update()
    {
        audioMixer.GetFloat("volume", out float volume);
        soundText.text = "Sound: " + ((volume == 0f) ? "On" : "Off");
    }
    public void TuneSounds()
    {
        audioMixer.GetFloat("volume", out float volume);
        audioMixer.SetFloat("volume", (volume == 0) ? -80f : 0f);

        Debug.Log(SaveSystem.LoadData().levelsPassed + "/" + SaveSystem.LoadData().levelsNumber);
    }
}
