using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private Transform _skinContainer;

    public UnitStats Stats { get; private set; }
    public string Name { get; private set; }

    private Skin _skin;

    public void SetName(string name)
    {
        Name = name;
        gameObject.name = name;
    }
    public void SetStats(UnitStats stats)
    {
        Stats = stats;
    }
    public void SetSkin(Skin skin)
    {
        _skin = skin;
        skin.transform.SetParent(_skinContainer);
    }
    public override string ToString()
    {
        var line = $"Mob: Name = {Name}, Stats: Level = {Stats.Level}, HP = {Stats.HP}, Speed = {Stats.Speed}";

        return line;
    }
}
