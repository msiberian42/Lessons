using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Data.score++;
        Debug.Log(Data.score);
        Destroy(this.gameObject);
    }
}
