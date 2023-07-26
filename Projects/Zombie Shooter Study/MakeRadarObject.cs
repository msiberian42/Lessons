using UnityEngine;
using UnityEngine.UI;

public class MakeRadarObject : MonoBehaviour
{
    [SerializeField] private Image image;

    private void Start()
    {
        Radar.RegisterRadarObject(gameObject, image);
    }

    private void OnDestroy()
    {
        Radar.RemoveRadarObject(gameObject);
    }
}
