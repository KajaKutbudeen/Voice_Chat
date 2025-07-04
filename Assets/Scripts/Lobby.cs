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

        [Header("Debug")]
       public byte Version = 0;
        

        [Header("Mic")]
        public Recorder _recorder;
        [SerializeField] private bool _micTransmit = false;
        [SerializeField] private Toggle _mic;

        [Header("Create a Room")]
        [SerializeField] private string roomname;
        [SerializeField] private int maxPlayers;
        [SerializeField] private bool ConnectedInRoom = false;

        [Header("Join Room")]
        [SerializeField] private TextMeshProUGUI _guestname;
        [SerializeField] private TextMeshProUGUI _roomName;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _username;     
        public UIManager uIManager;
        public GameObject Avatar;

        [Header("Sprite Swap")]
        public Image MicIcon;
        public Sprite Micon;
        public Sprite Micoff;

        private int id = 0;
           
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
            Debug.Log("Connecting.....");

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

            id = 1;
        }

       
        [PunRPC]
        public void changevalue()
        {
            Version += 1;
            Debug.Log("Version:" + Version);
        }
        public override void OnJoinedRoom()
        {           
              
            //Update Status
            ConnectedInRoom = true;

            //Disable LobbyUI
            //  uIManager.DisableLobbyUI();
            if(id == 1) uIManager.disableRoomCreation();
            else if(id == 2) uIManager.disableJoinRoom();              

            //Mic Transmisson
            _recorder.TransmitEnabled = _micTransmit;
            _mic.isOn = _micTransmit;
          
            Avatar.SetActive(true);
           

           
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
            if (_roomName.text.Length <= 1) { Debug.Log("No Room name or no Guest name"); return; }

            PhotonNetwork.NickName ="Hari";

            id = 2;          
                PhotonNetwork.JoinRoom("Manju");          
            

        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("Join Failed!!!!");         
        }

       public void MicTransmit(bool value)
        {
            _recorder.TransmitEnabled = value;

            if (value)
            {
                MicIcon.sprite = Micon;             
            }

            else
            {
                MicIcon.sprite = Micoff;               
            }
        }
    }
}