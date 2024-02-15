namespace PhotonMultiplayerGame.Features.Player
{
    using UnityEngine;
    using Photon.Pun;
    using PhotonMultiplayerGame.Features.Gameplay;
    using TMPro;

    public class PlayerController : MonoBehaviour, IPunObservable
    {
        public PhotonView PhotonView => photonView;

        private PhotonView photonView;
        private SpriteRenderer spriteRenderer;

        public Vector2Int Direction = default;
        public Vector2Int GamePosition = default;

        public Sprite OtherPlayerSprite;
        public Sprite DeadPlayerSprite;

        public Transform Ladder;
        public bool isDead;

        public TextMeshProUGUI NicknameText;
        public int Score;

        private void Start()
        {
            photonView = GetComponent<PhotonView>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            GamePosition.x = (int) transform.position.x;
            GamePosition.y = (int) transform.position.y;
            FindObjectOfType<MapController>().AddPlayer(this);
            
            NicknameText.SetText(photonView.Owner.NickName);
            if (!photonView.IsMine)
            {
                spriteRenderer.sprite = OtherPlayerSprite;
                NicknameText.color = Color.red;
            }
        }

        private void Update()
        {
            if (photonView.IsMine && !isDead)
            {
                if (Input.GetKey(KeyCode.LeftArrow)) Direction = Vector2Int.left;
                if (Input.GetKey(KeyCode.RightArrow)) Direction = Vector2Int.right;
                if (Input.GetKey(KeyCode.UpArrow)) Direction = Vector2Int.up;
                if (Input.GetKey(KeyCode.DownArrow)) Direction = Vector2Int.down;
            }

            if (Direction == Vector2Int.left) spriteRenderer.flipX = false;
            if (Direction == Vector2Int.right) spriteRenderer.flipX = true;

            transform.position = Vector3.Lerp(transform.position, (Vector2)GamePosition, Time.deltaTime * 3);
        }

        public void Kill()
        {
            isDead = true;
            spriteRenderer.sprite = DeadPlayerSprite;

            SetLadderLenght(0);
            FindObjectOfType<MapController>().RemovePlayer(this);
        }

        public void SetLadderLenght(int lenght)
        {
            for (int i = 0; i < Ladder.childCount; i++)
            {
                Ladder.GetChild(i).gameObject.SetActive(i < lenght);
            }

            while (Ladder.childCount < lenght)
            {
                Transform lastTile = Ladder.GetChild(Ladder.childCount - 1);
                Instantiate(lastTile, lastTile.position + Vector3.down, Quaternion.identity, Ladder);
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(Direction);
            }
            else
            {
                Direction = (Vector2Int)stream.ReceiveNext();
            }
        }

    }
}