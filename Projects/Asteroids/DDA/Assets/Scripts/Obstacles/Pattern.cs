using UnityEngine;

public class Pattern : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles = new GameObject[4];    
    private ObstaclesManager manager => 
        GameObject.FindGameObjectWithTag("Logic").GetComponent<ObstaclesManager>();

    void Start()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (obstacles[i] != null)
                Instantiate(obstacles[i], new Vector3(manager.GetPosition(i + 1), 7f, 0f), transform.rotation);
        }
        Destroy(gameObject);
    }
}
