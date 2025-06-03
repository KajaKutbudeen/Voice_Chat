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

   

    public void DisableLobbyUI()
    {
        RoomCreation.SetActive(false);
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
