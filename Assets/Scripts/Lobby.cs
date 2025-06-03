using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using WebSocketSharp;
using Photon.Voice.Unity;

namespace Photon.Pun.UtilityScripts
{
    public class Lobby : MonoBehaviourPunCallbacks
    {
        
       public byte Version = 1;

        [Header("Mic")]
        public Recorder _recorder;
        [SerializeField] private bool _micTransmit = false;
        [SerializeField] private Toggle _mic;

        [Header("Create a Room")]
        [SerializeField] private string roomname;
        [SerializeField] private int maxPlayers;
        [SerializeField] private bool ConnectedInRoom = false;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _username;
        [SerializeField] private TextMeshProUGUI _roomName;
        public UIManager uIManager;
        public GameObject Avatar;

        [Header("Sprite Swap")]
        public Image MicIcon;
        public Sprite Micon;
        public Sprite Micoff;

     
        

        public void Start()
        {
            Application.targetFrameRate = 60;
            Connect();
        }

        private void Update()
        {
            CheckRoom();
        }

        private void CheckRoom()
        {
            if (PhotonNetwork.InRoom)
            {
                ConnectedInRoom = true;
            }
            else
            {
                ConnectedInRoom = false;
            }
        }

        public void Connect()
        {
            Debug.Log("ConnectAndJoinRandom.ConnectNow() will now call: PhotonNetwork.ConnectUsingSettings().");

            PhotonNetwork.ConnectUsingSettings();

            PhotonNetwork.GameVersion = this.Version + "." + SceneManagerHelper.ActiveSceneBuildIndex;

            if (PhotonNetwork.IsConnected)
            {
                Debug.Log("connected");
            }
            else
            {
                Debug.Log("Not Connected or didnt initialized");
            }
        }
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to Master Server.");
           
        }



        public void CreateRoom()
        {
            
            if (_username.text.Length <= 1) { Debug.Log("No username!!!"); return; }
            PhotonNetwork.NickName = _username.text;

            RoomOptions roomOptions = new RoomOptions() {
                MaxPlayers = this.maxPlayers,
                IsVisible = true,
                IsOpen = true,           
            };

            PhotonNetwork.CreateRoom(roomname, roomOptions, TypedLobby.Default);

            PhotonNetwork.NickName = _username.text;

           
          //  _lobbyname.text = PhotonNetwork.CurrentRoom.Name;
        }

        public override void OnJoinedRoom()
        {
           
                // THIS is where you are actually in the room!
                Debug.Log("Successfully joined room: " + PhotonNetwork.CurrentRoom.Name);
            Debug.Log($"Players in room ({PhotonNetwork.CurrentRoom.PlayerCount}):");
            foreach (Player p in PhotonNetwork.CurrentRoom.Players.Values)
            {
                Debug.Log($"  - {p.NickName} (IsLocal: {p.IsLocal})");
            }

            ConnectedInRoom = true; // Update your state flag           
            uIManager.DisableLobbyUI();
            _recorder.TransmitEnabled = _micTransmit;
            _mic.isOn = _micTransmit;
            Debug.Log("Room: " + PhotonNetwork.CurrentRoom.Name); // Display the room name in UI'
            Avatar.SetActive(true);
           

            // Now you can load your game scene or spawn player prefabs, etc.
            // PhotonNetwork.LoadLevel("GameScene");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log($"Create Room Failed: {message} (Code: {returnCode})");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogError($"Join Room Failed: {message} (Code: {returnCode})");
        }
        public void Joinroom()
        {
            if (_roomName.text.Length <= 1) { Debug.Log("No Room name"); return; }

            PhotonNetwork.NickName = "hari";

            PhotonNetwork.JoinRoom("Manju");
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("OnJoinRandomFailed() was called by PUN. No random room available in region [" + PhotonNetwork.CloudRegion + "], so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");         
        }

       public void MicTransmit(bool value)
        {
            _recorder.TransmitEnabled = value;

            if (value)
            {
                MicIcon.sprite = Micon;
                Debug.Log("On");
            }

            else
            {
                MicIcon.sprite = Micoff;
                Debug.Log("off");
            }
        }
    }
}