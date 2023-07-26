using UnityEngine;

public class PoolExample : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Cube prefab;

    private PoolMono<Cube> pool;

    private void Start()
    {
        this.pool = new PoolMono<Cube> (this.prefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
    }
    private void Update () 
    {
        if (Input.GetMouseButtonDown(0))
            CreateCube();
            
    }
    private void CreateCube()
    {
        var rX = Random.Range (-5f, 5f);
        var rZ = Random.Range (-5f, 5f);
        var rY = 0;

        var rPosition = new Vector3(rX, rY, rZ);
        var cube = this.pool.GetFreeElement();
        cube.transform.position = rPosition;
    }
}
