using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] refuelSounds;
    [SerializeField] private AudioClip[] crashSounds;
    [SerializeField] private AudioClip extingSound;
    [SerializeField] private AudioClip[] coinSound;
    [SerializeField] private AudioClip clickSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayRefuelSound()
    {
        audioSource.PlayOneShot(refuelSounds[Random.Range(0, refuelSounds.Length)]);
    }
    public void PlayCrashSound()
    {
        audioSource.PlayOneShot(crashSounds[Random.Range(0, crashSounds.Length)], 0.3f);
    }
    public void PlayExtingSound()
    {
        audioSource.PlayOneShot(extingSound);
    }
    public void PlayCoinSound()
    {
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.PlayOneShot(coinSound[Random.Range(0, coinSound.Length)]);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
