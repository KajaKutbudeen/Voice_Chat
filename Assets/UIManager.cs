using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("LobbyUI")]
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
    
}
