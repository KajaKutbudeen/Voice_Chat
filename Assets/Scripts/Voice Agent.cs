using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class VoiceAgent : MonoBehaviourPun
{
    public Lobby _lobby;
    private PhotonView _pv;
    [SerializeField] private bool isadded = false;
    private void Awake()
    {
        _lobby = GameObject.Find("Pun").GetComponent<Lobby>();
       
    }

    private void Start()
    {
       _pv = GetComponent<PhotonView>();
        if( _pv != null )
        {
            _pv.RPC("change", RpcTarget.AllViaServer);
        }
    }
   
   
    [PunRPC]
    void change()
    {
        if (!isadded)
        {
            _lobby.changevalue();
            isadded = true;
        }
    }
}
