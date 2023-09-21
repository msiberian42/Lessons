using UnityEngine;

public class MobBuilder
{
    private Mob _prefab;
    private Skin _skinPrefab;
    private UnitStats _unitStats;
    private string _mobName;

    public MobBuilder WithRootPrefab(Mob prefab)
    {
        _prefab = prefab;
        return this;
    }
    public MobBuilder WithSkin(Skin skin)
    {
        _skinPrefab = skin;
        return this;
    }
    public MobBuilder WithStats(UnitStats stats)
    {
        _unitStats = stats;
        return this;
    }
    public MobBuilder WithName(string mobName)
    {
        _mobName = mobName;
        return this;
    }

    public Mob BuildMob(Transform container = null)
    {
        var createdMob = Object.Instantiate(_prefab, container);
        var createdSkin = Object.Instantiate(_skinPrefab);

        createdMob.SetSkin(createdSkin);
        createdMob.SetName(_mobName);
        createdMob.SetStats(_unitStats);

        return createdMob;
    }
    public MobBuilder Reset()
    {
        _prefab = null;
        _skinPrefab = null;
        _unitStats = null;
        _mobName = null;
        return this;
    }
}
