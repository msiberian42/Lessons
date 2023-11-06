using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Platform : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    private Collider2D coll;
    private int currentWaypoint = 0;
    private float delta = 0.5f;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (waypoints.Count > 0)
            MovePlatform();
    }
    private void MovePlatform()
    {
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) <= delta)
            SwitchCurrentWaypoint();

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypoint].transform.position, moveSpeed * Time.deltaTime);
    }
    private void SwitchCurrentWaypoint()
    {
        if (currentWaypoint == waypoints.Count - 1)
            currentWaypoint = 0;
        else
            currentWaypoint++;
    }
    public void TurnOffCollision(Collider2D collider)
    {
        Physics2D.IgnoreCollision(coll, collider);
    }
    public void TurnOnCollision(Collider2D collider)
    {
        Physics2D.IgnoreCollision(coll, collider, false);
    }
}
