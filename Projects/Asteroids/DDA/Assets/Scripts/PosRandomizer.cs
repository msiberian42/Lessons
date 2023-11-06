using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosRandomizer : MonoBehaviour
{
    protected ObstaclesManager manager =>
        GameObject.FindGameObjectWithTag("Logic").GetComponent<ObstaclesManager>();
    void Start()
    {
        transform.position = new Vector3(manager.GetPosition(Random.Range(1, 5)), transform.position.y);
    }
}
