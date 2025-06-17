using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Voice.PUN;
using UnityEngine;

public class VoiceAgent : MonoBehaviourPunCallbacks
{

    [Header("References")]
   
    public UIManager _uimanager;
    private PhotonView _pv;
    private PhotonVoiceView _pvVoice;
    [SerializeField]
    private GameObject _voiceAvatar;

    [SerializeField] private bool isadded = false;
    [SerializeField] private bool isSpeaking = false;
    public int id = 0;
    private void Awake()
    {
      
       _uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        id = PhotonNetwork.PlayerList.Length - 1;

    }
   
    private void Start()
    {
      
       _pv = GetComponent<PhotonView>();
        _pvVoice = GetComponent<PhotonVoiceView>();
        if(_pv.IsMine)
        {
            Debug.Log("Mine yes");
            _uimanager.Getavatar(id);
        }
        else
        {
            Debug.Log("not mine");
            id = 0;
        }
            _voiceAvatar = _uimanager.GetAvatarObj(id);
    } 

    private void Update()
    {
        if (_pvVoice != null)
        {
            isSpeaking = _pvVoice.IsSpeaking;
        }
    }

    [PunRPC]
    void change()
    {
        if (!isadded)
        {
          //  _lobby.changevalue();
      _uimanager.PlayerAvatar();
            isadded = true;
        }
    }
}
