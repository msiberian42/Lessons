using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource shot;

    public void Fire()
    {
        shot.Play();
    }
}
