using UnityEngine;

public class EngineSound : MonoBehaviour
{
    private AudioSource engineSound;

    private void Start()
    {
        engineSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        engineSound.panStereo = transform.position.x * 0.35f;
    }
}
