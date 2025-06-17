using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class UIManager : MonoBehaviourPunCallbacks //, IPunObservable
{
    [Header("LobbyUI")]
    public GameObject LobbyCanvas;
    public GameObject StartCanvas;
    public GameObject RoomCreation;
    public GameObject JoinRoom;

    [Header("MainScene")]
    public GameObject Mic;

    public GameObject _createnbut;
    public GameObject _JoinRoombut;

    [Header("Avatars")]
    public GameObject[] Avartars;
    [SerializeField] private bool avatarcheck = false;
    private PhotonView _pv;
    [SerializeField] int count = -1;

    private void Start()
    {
        _pv = GetComponent<PhotonView>();
    }

    public void DisableLobbyUI()
    {
        RoomCreation.SetActive(false);
        JoinRoom.SetActive(false);
        MainUiSceneEnable();
    }
    public void EnableRC()
    {
        RoomCreation.SetActive(true);
        _createnbut.SetActive(false);
        _JoinRoombut.SetActive(false);
    }

    public void EnableJR()
    {
        JoinRoom.SetActive(true);
        _createnbut.SetActive(false);
        _JoinRoombut.SetActive(false);
    }

    public void disableRoomCreation()
    {
        RoomCreation.SetActive(false);
        MainUiSceneEnable();
    }

    public void disableJoinRoom()
    {
        JoinRoom.SetActive(false);
        MainUiSceneEnable();
    }

    public void MainUiSceneEnable()
    {
        Mic.SetActive(true);
    }
    
    public void EnableLobbyCanvas()
    {
        StartCanvas.SetActive(false);
        LobbyCanvas.SetActive(true);
    }

    //This is the area of Passing value across the network

    
    public void Getavatar(int id)
    {
        Debug.Log("Getavatar passed");
        _pv.RPC("setavatar", RpcTarget.All, id);

    }
    [PunRPC]
    public void setavatar(int id)
    {
        Avartars[id].SetActive(true);        
    }
    
    public GameObject GetAvatarObj(int id)
    {
        return Avartars[id];
    }
    [PunRPC]
    public void PlayerEntry()
    {
        int playercount = PhotonNetwork.PlayerList.Length;
        Avartars[playercount - 1].SetActive(true);
   /*     for (int i = 0; i < playercount; i++)
        {
            Avartars[i].SetActive(true);
           
            if (Avartars[i] != Avartars[playercount -1])
            {
                Avartars[i].GetComponent<AvatarVoice>().enabled = false;
            }
            else
            {
                Avartars[i].GetComponent<AvatarVoice>().enabled = true;
            }
        }          */   
    }

    public void PlayerAvatar()
    {
        _pv.RPC("PlayerEntry", RpcTarget.MasterClient);
    }
    /*
      [PunRPC]
        public void EnableAvatar(int avatarIndex)
        {
            if (avatarcheck) return;
            Debug.Log("Count: " + avatarIndex);
            Debug.Log(Avartars[avatarIndex].ToString());
            avatarcheck = true;
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(count);
            }
            else
            {
                count = (int)stream.ReceiveNext();
            }
            Debug.Log("Method 2");
        }

        public void CheckAvatar()
        {
            // count += 1;
            // _pv.RPC("EnableAvatar", RpcTarget.All,count);
            Debug.Log("1st method");

            //    _pv.RPC("Addupcount", RpcTarget.All);

        }

        [PunRPC]
        public void Addupcount()
        {
            if(avatarcheck) return;
            foreach (Player photonPlayer in PhotonNetwork.PlayerList)
            {

                 Debug.Log($"Player {photonPlayer.NickName} controls GameObject: {photonPlayer.IsLocal}");

            }       
            avatarcheck = true;
        }

        */
    public void Exit()
    {
        Application.Quit();
    }
}
