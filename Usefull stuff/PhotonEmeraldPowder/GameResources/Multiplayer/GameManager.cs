namespace PhotonMultiplayerGame.Features.Multiplayer 
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Photon.Pun;
    using Photon.Realtime;
    using ExitGames.Client.Photon;
    using PhotonMultiplayerGame.Features.Gameplay;
    using Random = UnityEngine.Random;
    using System.Linq;
    using PhotonMultiplayerGame.Features.Player;

    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private GameObject playerPrefab = default;
        [SerializeField]
        private MapController mapController = default;

        private void Start()
        {
            PhotonNetwork.Instantiate(playerPrefab.name, 
                new Vector3(Random.Range(5, 15), Random.Range(2, 8), 0), Quaternion.identity);

            //TODO: удалить потом?
            //PhotonNetwork.AutomaticallySyncScene = true;

            PhotonPeer.RegisterType(typeof(Vector2Int), 242, SerializeVector2Int, DeserializeVector2Int);
            PhotonPeer.RegisterType(typeof(SyncData), 243, SyncData.SerializeData, SyncData.DeserializeData);
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            // Когда текущий игрок покидает комнату
            SceneManager.LoadScene("Lobby");
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                mapController.SendSyncData(newPlayer);
            }

            Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            //PlayerController player = mapController.Players.First(p => p.PhotonView.Owner == null);
            //PlayerController player = mapController.Players.First(p => p.PhotonView.CreatorActorNr == 0);
            PlayerController player = mapController.Players.First(p => p.PhotonView.CreatorActorNr == otherPlayer.ActorNumber);
            player?.Kill();

            Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
        }

        public static object DeserializeVector2Int(byte[] data)
        {
            Vector2Int result = new Vector2Int();

            result.x = BitConverter.ToInt32(data, 0);
            result.y = BitConverter.ToInt32(data, 4);

            return result;
        }

        public static byte[] SerializeVector2Int(object obj)
        {
            Vector2Int vector = (Vector2Int)obj;
            byte[] result = new byte[8];

            BitConverter.GetBytes(vector.x).CopyTo(result, 0);
            BitConverter.GetBytes(vector.y).CopyTo(result, 4);

            return result;
        }
    }
}
