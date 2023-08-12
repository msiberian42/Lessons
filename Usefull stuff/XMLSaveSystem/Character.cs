using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction = Vector3.zero;

    private void Update()
    {
        /*direction = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            direction.x = -1;
        if (Input.GetKey(KeyCode.D))
            direction.x = 1;
        if (Input.GetKey(KeyCode.S))
            direction.z = -1;
        if (Input.GetKey(KeyCode.W))
            direction.z = 1;*/

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        transform.position += direction * speed * Time.deltaTime;
    }
}
