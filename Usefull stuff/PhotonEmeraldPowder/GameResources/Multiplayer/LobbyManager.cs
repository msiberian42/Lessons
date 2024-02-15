namespace PhotonMultiplayerGame.Features.Multiplayer
{
    using UnityEngine;
    using UnityEngine.UI;
    using Photon.Pun;

    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private Text logText = default;
        public InputField NicknameInput;

        private const string NICKNAME = "Nickname";

        private void Start()
        {
            string nick = PlayerPrefs.GetString(NICKNAME, "Player " + Random.Range(1000, 9999));
            PhotonNetwork.NickName = nick;
            NicknameInput.text = nick;
            Log("Player`s name is set to: " + PhotonNetwork.NickName);

            //TODO: удалить потом
            //PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Log("Connected to master");
        }

        public void CreateRoom()
        {
            PhotonNetwork.NickName = NicknameInput.text;
            PlayerPrefs.SetString(NICKNAME, NicknameInput.text);

            PhotonNetwork.CreateRoom(null, 
                new Photon.Realtime.RoomOptions { 
                    MaxPlayers = 20, CleanupCacheOnLeave = true });
        }

        public void JoinRandomRoom()
        {
            PhotonNetwork.NickName = NicknameInput.text;
            PlayerPrefs.SetString(NICKNAME, NicknameInput.text);
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            Log("On joined room");

            PhotonNetwork.LoadLevel("Gameplay");
        }

        private void Log(string message)
        {
            Debug.Log(message);
            logText.text += "\n";
            logText.text += message;
        }
    }
}