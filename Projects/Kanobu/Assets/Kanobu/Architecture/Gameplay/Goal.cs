using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private UnitColor color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            if (collision.gameObject.GetComponent<UnitConstructor>().unitColor == color)
                return;

            ScoreCounter.DecreaseScore(color);
        }
    }
}
