namespace PhotonMultiplayerGame.Features.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Photon.Pun;
    using Photon.Realtime;
    using ExitGames.Client.Photon;
    using PhotonMultiplayerGame.Features.Player;
    using PhotonMultiplayerGame.Features.Multiplayer;

    public class MapController : MonoBehaviour, IOnEventCallback
    {
        public List<PlayerController> Players => players;

        [SerializeField]
        private GameObject blockPrefab = default;
        [SerializeField]
        private PlayerTop top;

        private GameObject[,] cells;

        [SerializeField]
        private List<PlayerController> players = new List<PlayerController>();

        private double lastTickTime;

        private void OnEnable() => PhotonNetwork.AddCallbackTarget(this);

        private void OnDisable() => PhotonNetwork.RemoveCallbackTarget(this);

        private void Start()
        {
            cells = new GameObject[20, 10];

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    cells[x,y] = Instantiate(blockPrefab, new Vector3(x, y), Quaternion.identity, transform);
                }
            }
        }

        private void Update()
        {
            if (PhotonNetwork.Time > lastTickTime + 1 && PhotonNetwork.IsMasterClient
                && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
            {
                // Разослать всем события

                Vector2Int[] directons = players
                    .Where(p => !p.isDead)
                    .OrderBy(p => p.PhotonView.Owner.ActorNumber)
                    .Select(p => p.Direction)
                    .ToArray();

                RaiseEventOptions options = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
                SendOptions sendOptions = new SendOptions { Reliability = true };
                PhotonNetwork.RaiseEvent(42, directons, options, sendOptions);

                // Сделать шаг игры

                PerformTick(directons);
            }
        }

        public void SendSyncData(Player player)
        {
            SyncData data = new SyncData();

            data.Positions = new Vector2Int[players.Count];
            data.Scores = new int[players.Count];

            PlayerController[] sortedPlayers = players
                .Where(p => !p.isDead)
                .OrderBy(p => p.PhotonView.Owner.ActorNumber)
                .ToArray();

            for (int i = 0; i < sortedPlayers.Length; i++)
            {
                data.Positions[i] = sortedPlayers[i].GamePosition;
                data.Scores[i] = sortedPlayers[i].Score;
            }

            data.MapData = new BitArray(20 * 10);

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    data.MapData.Set(x + y * cells.GetLength(0), cells[x, y].activeSelf);
                }
            }

            RaiseEventOptions options = new RaiseEventOptions { TargetActors = new int[] { player.ActorNumber} };
            SendOptions sendOptions = new SendOptions { Reliability = true };

            PhotonNetwork.RaiseEvent(43, data, options, sendOptions);
        }

        private void PerformTick(Vector2Int[] directons)
        {
            if (players.Count != directons.Length) 
            {
                return;                
            }

            PlayerController[] sortedPlayers = players
                .Where(p => !p.isDead)
                .OrderBy(p => p.PhotonView.Owner.ActorNumber)
                .ToArray();

            int i = 0;

            foreach (var player in sortedPlayers)
            {
                player.Direction = directons[i++];

                MinePlayerBlock(player);
            }

            foreach (var player in sortedPlayers)
            {
                MovePlayer(player);
            }

            foreach (var player in players.Where(p => p.isDead))
            {
                Vector2Int pos = player.GamePosition;
                while (pos.y > 0 && !cells[pos.x, pos.y - 1].activeSelf)
                {
                    
                    pos.y--;
                }
                player.GamePosition = pos;
            }

            top.SetText(players);
            lastTickTime = PhotonNetwork.Time;
        }

        private void MinePlayerBlock(PlayerController player)
        {
            if (player.Direction == Vector2Int.zero) return;

            Vector2Int targetPos = player.GamePosition + player.Direction;

            // Копаем блок
            if (targetPos.x < 0) return;
            if (targetPos.y < 0) return;
            if (targetPos.x >= cells.GetLength(0)) return;
            if (targetPos.y >= cells.GetLength(1)) return;

            if (cells[targetPos.x, targetPos.y].activeSelf)
            {
                cells[targetPos.x, targetPos.y].SetActive(false);
                player.Score++;
            }

            // Проверяем, не убило ли нас этим копанием
            Vector2Int pos = targetPos;
            PlayerController minePlayer = players.First(p => p.PhotonView.IsMine);
            if (minePlayer != player)
            {
                while (pos.y < cells.GetLength(1) && !cells[pos.x, pos.y].activeSelf)
                {
                    if (pos == minePlayer.GamePosition)
                    {
                        PhotonNetwork.LeaveRoom();
                        break;
                    }

                    pos.y++;
                }
            }
        }

        private void MovePlayer(PlayerController player)
        {
            player.GamePosition += player.Direction;

            if (player.GamePosition.x < 0) player.GamePosition.x = 0;
            if (player.GamePosition.y < 0) player.GamePosition.y = 0;
            if (player.GamePosition.x >= cells.GetLength(0)) player.GamePosition.x = cells.GetLength(0) - 1;
            if (player.GamePosition.y >= cells.GetLength(1)) player.GamePosition.y = cells.GetLength(1) - 1;

            int ladderLenght = 0;
            Vector2Int pos = player.GamePosition;
            while (pos.y > 0 && !cells[pos.x, pos.y - 1].activeSelf)
            {
                ladderLenght++;
                pos.y--;
            }
            player.SetLadderLenght(ladderLenght);
        }

        public void AddPlayer(PlayerController player)
        {
            players.Add(player);

            cells[player.GamePosition.x, player.GamePosition.y].SetActive(false);
        }

        public void RemovePlayer(PlayerController player)
        {
            players.Remove(player);
        }

        public void OnEvent(EventData photonEvent)
        {
            switch (photonEvent.Code)
            {
                case 42:
                    Vector2Int[] directons = (Vector2Int[])photonEvent.CustomData;
                    PerformTick(directons);
                    break;

                case 43:
                    SyncData data = (SyncData)photonEvent.CustomData;
                    StartCoroutine(OnSyncDataReceived(data));
                    break;
            }
        }

        private IEnumerator OnSyncDataReceived(SyncData data)
        {
            PlayerController[] sortedPlayers;

            do
            {
                yield return null;
                sortedPlayers = players
                    .Where(p => !p.isDead)
                    .Where(p => !p.PhotonView.IsMine)
                    .OrderBy(p => p.PhotonView.Owner.ActorNumber)
                    .ToArray();

            } while (sortedPlayers.Length != data.Positions.Length);

            
            for (int i = 0; i < sortedPlayers.Length; i++)
            {
                sortedPlayers[i].GamePosition = data.Positions[i];
                sortedPlayers[i].Score = data.Scores[i];

                sortedPlayers[i].transform.position = (Vector2)sortedPlayers[i].GamePosition;
            }

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    bool cellActive = data.MapData.Get(x + y * cells.GetLength(0));
                    if (!cellActive) cells[x, y].SetActive(cellActive);
                }
            }
        }
    }
}