using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private Mob _mobRootPrefab;
    [SerializeField] private Skin _skinOgrPrefab;
    [SerializeField] private Skin _skinHumanPrefab;

    private UnitStats _ogrStats = new UnitStats
    {
        HP = 100,
        Level = 1,
        Speed = 10
    };
    private UnitStats _humanStats = new UnitStats
    {
        HP = 50,
        Level = 2,
        Speed = 13
    };

    private void Start()
    {
        var mobBuilder = new MobBuilder();

        var createdOgr = mobBuilder
            .Reset()
            .WithRootPrefab(_mobRootPrefab)
            .WithName("Ogr")
            .WithStats(_ogrStats)
            .WithSkin(_skinOgrPrefab)
            .BuildMob();

        var createdHuman = mobBuilder
            .Reset()
            .WithRootPrefab(_mobRootPrefab)
            .WithName("Human")
            .WithStats(_humanStats)
            .WithSkin(_skinHumanPrefab)
            .BuildMob();

        Debug.Log(createdOgr);
        Debug.Log(createdHuman);
    }
}
