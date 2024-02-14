namespace PhotonLesson
{
    using UnityEngine;
    using UnityEngine.UI;
    using Photon.Pun;

    public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private InputField createInput = default;

        [SerializeField]
        private InputField joinInput = default;

        public void CreateRoom()
        {
            Debug.Log("Create " + createInput.text);
            PhotonNetwork.CreateRoom(createInput.text);
        }

        public void JoinRoom()
        {
            Debug.Log("Join " + joinInput.text);
            PhotonNetwork.JoinRoom(joinInput.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("Gameplay");
        }
    }
}