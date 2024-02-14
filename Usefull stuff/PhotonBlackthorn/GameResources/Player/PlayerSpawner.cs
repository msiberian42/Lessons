namespace PhotonLesson
{
    using UnityEngine;
    using Photon.Pun;

    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab = default;

        [SerializeField]
        private float maxX = 0f;
        [SerializeField] 
        private float maxY = 0f;

        private void Start()
        {
            Vector2 randPos = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
            PhotonNetwork.Instantiate(prefab.name, randPos, Quaternion.identity);
        }
    }
}