using UnityEngine;

[CreateAssetMenu(fileName = "ChestInfo", menuName = "Gameplay/New ChestInfo")]
public class ChestInfo : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Sprite _spriteIcon;

    public string id => _id;
    public GameObject prefab => _prefab;
    public Sprite spriteIcon => _spriteIcon;




}
