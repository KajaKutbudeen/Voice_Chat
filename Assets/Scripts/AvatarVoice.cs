using Photon.Pun;
using UnityEngine;

public class AvatarVoice : MonoBehaviourPunCallbacks
{
    public GameObject go;
    public int id = 0;
    private bool assigned = false;
    private bool currentplayer = false;
    private void Start()
    {
        int playercount = PhotonNetwork.PlayerList.Length;

        if(id == playercount-1) currentplayer = true;

        if (!assigned && currentplayer)
        {
            Debug.Log("Assigning");
            foreach (var view in PhotonNetwork.PhotonViewCollection)
            {
              
                if (view.IsMine)
                {
                  //  Debug.Log("Avatarid:" + id + "voice agent id:" + view.gameObject.GetComponent<VoiceAgent>().Getid());
                    go = view.gameObject;
                    go.name = "Player" + gameObject.name;
                    assigned = true;
                   
                }
            }
        }
    }
}
