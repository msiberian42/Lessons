namespace PhotonLesson 
{
    using UnityEngine;
    using UnityEngine.UI;

    public class CoinsCounter : MonoBehaviour
    {
        [SerializeField]
        private Text text = default;

        private int counter = 0;

        private void Awake() => Coin.onCoinCollected += OnCoinCollected;

        private void OnDestroy() => Coin.onCoinCollected -= OnCoinCollected;

        private void OnCoinCollected()
        {
            counter++;
            text.text = counter.ToString();
        }
    }
}
