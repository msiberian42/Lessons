namespace PhotonLesson
{
    using System;
    using UnityEngine;

    public class Coin : MonoBehaviour
    {
        public static event Action onCoinCollected = delegate { };

        private PlayerController playerController = default;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            playerController = collision.GetComponent<PlayerController>();

            if (playerController)
            {
                onCoinCollected();
                gameObject.SetActive(false);
            }
        }
    }
}
