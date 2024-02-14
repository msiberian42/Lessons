namespace PhotonLesson
{
    using UnityEngine;
    using Photon.Pun;

    /// <summary>
    /// Инпут с ПК
    /// </summary>
    public class PCPlayerInput : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _playerController = default;

        private Vector2 _direction = default;

        private PhotonView _view = default;

        private void Awake()
        {
            _view = GetComponent<PhotonView>();
        }

        private void Update()
        {
            if (_view.IsMine)
            {
                _direction.x = Input.GetAxis("Horizontal");
                _direction.y = Input.GetAxis("Vertical");
            }
        }

        private void FixedUpdate() => _playerController.MovePlayer(_direction);
    }
}
