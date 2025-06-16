using UnityEngine;

public class UIManager : MonoBehaviour
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

    public void Exit()
    {
        Application.Quit();
    }
}
